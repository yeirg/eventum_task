using ET.BuildingBlocks.Infrastructure.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ET.BuildingBlocks.Infrastructure.Persistence;

/// <summary>
/// Базовый контекст данных.
/// </summary>
public class ApplicationDbContext(
    DbContextOptions options,
    IEnumerable<IDbContextInterceptor>? interceptors = null) : DbContext(options)
{
    private readonly IEnumerable<IDbContextInterceptor> _interceptors =
        interceptors ?? Enumerable.Empty<IDbContextInterceptor>();

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        BeforeSave();

        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        BeforeSave();

        return await base.SaveChangesAsync(cancellationToken);
    }

    public override async Task<int> SaveChangesAsync(
        bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = default)
    {
        BeforeSave();

        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void BeforeSave()
    {
        ChangeTracker.DetectChanges();

        foreach (var interceptor in _interceptors)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                interceptor.BeforeSave(entry);
            }
        }
    }
}