using ET.BuildingBlocks.Application.Consistence.Abstractions;
using ET.BuildingBlocks.Application.EventSystem;
using ET.BuildingBlocks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ET.BuildingBlocks.Application.Consistence.Services;

public sealed class UnitOfWork<TContext>(
    TContext dbContext,
    ILogger<UnitOfWork<TContext>> logger,
    IPublisher domainEventPublisher,
    IPublisher mediator)
    : IUnitOfWork
    where TContext : DbContext
{
    /// <inheritdoc/>
    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        if (!dbContext.ChangeTracker.HasChanges())
        {
            return;
        }
        
        if (dbContext.Database.CurrentTransaction is not null)
        {
            return;
        }

        var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            await dbContext.SaveChangesAsync(cancellationToken);
            await DispatchEventsAsync(cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while commiting changes");
            await transaction.RollbackAsync(cancellationToken);

            await mediator.Publish(ChangesCommittedEvent.Failure(ex.Message), CancellationToken.None);
            throw;
        }

        await mediator.Publish(ChangesCommittedEvent.Success(), CancellationToken.None);
    }

    private async Task DispatchEventsAsync(CancellationToken cancellationToken = default)
    {
        while (true)
        {
            var aggregateRoots = dbContext.ChangeTracker.Entries<IDomainEventContainer>()
                .Where(x => x.Entity.DomainEvents.Count != 0)
                .Select(e => e.Entity)
                .ToList();

            if (aggregateRoots.Count == 0) 
                return;

            var domainEvents = aggregateRoots
                .SelectMany(x => x.DomainEvents)
                .OrderBy(q => q.OccuredOn)
                .ToArray();
            
            aggregateRoots.ForEach(aggregate => aggregate.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
            {
                await domainEventPublisher.Publish(domainEvent, cancellationToken);
            }
        }
    }
}