using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ET.BuildingBlocks.Domain;
using ET.BuildingBlocks.Domain.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ET.BuildingBlocks.Infrastructure.Persistence;

/// <inheritdoc/>
public class EfRepository<TAggregateRoot> : IRepository<TAggregateRoot>
    where TAggregateRoot : AggregateRoot<Guid>
{
    private readonly IMapper _mapper;
    protected readonly DbSet<TAggregateRoot> Set;

    protected EfRepository(DbContext dbContext, IMapper mapper)
    {
        _mapper = mapper;
        Set = dbContext.Set<TAggregateRoot>();
    }

    /// <inheritdoc/>
    public virtual Task<List<TAggregateRoot>> GetListAsync(
        ISpecification<TAggregateRoot>? specification = null,
        CancellationToken cancellationToken = default)
    {
        return ApplySpecification(specification)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public virtual Task<List<TModel>> GetListAsync<TModel>(
        ISpecification<TAggregateRoot>? specification = null,
        CancellationToken cancellationToken = default)
    {
        return ApplySpecification(specification)
            .ProjectTo<TModel>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public virtual Task<TAggregateRoot?> GetFirstOrDefaultAsync(
        ISpecification<TAggregateRoot>? specification = null,
        CancellationToken cancellationToken = default)
    {
        return ApplySpecification(specification)
            .FirstOrDefaultAsync(cancellationToken);
    }
    
    /// <inheritdoc/>
    public virtual Task<TModel?> GetFirstOrDefaultAsync<TModel>(
        ISpecification<TAggregateRoot>? specification = null,
        CancellationToken cancellationToken = default)
    {
        return ApplySpecification(specification)
            .ProjectTo<TModel>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public virtual Task<bool> ExistAsync(
        ISpecification<TAggregateRoot>? specification = null,
        CancellationToken cancellationToken = default)
    {
        return ApplySpecification(specification)
            .AnyAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public virtual Task<int> CountAsync(
        ISpecification<TAggregateRoot>? specification = null, 
        CancellationToken cancellationToken = default)
    {
        return ApplySpecification(specification)
            .CountAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public virtual Task UpdateAsync(params TAggregateRoot[] aggregateRoots)
    {
        Set.UpdateRange(aggregateRoots);
        
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public virtual Task AddAsync(params TAggregateRoot[] aggregateRoots)
    {
        Set.AddRange(aggregateRoots);
        
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public virtual Task HardDeleteAsync(params TAggregateRoot[] aggregateRoots)
    {
        Set.RemoveRange(aggregateRoots);
        
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public virtual Task HardDeleteAsync(ISpecification<TAggregateRoot> specification)
    {
        ApplySpecification(specification)
            .ExecuteDeleteAsync(CancellationToken.None);
        
        return Task.CompletedTask;
    }

    private IQueryable<TAggregateRoot> ApplySpecification(ISpecification<TAggregateRoot>? specification)
    {
        if (specification is null)
        {
            return Set;
        }

        return SpecificationEvaluator.Default.GetQuery(
            query: Set,
            specification: specification);
    }
}