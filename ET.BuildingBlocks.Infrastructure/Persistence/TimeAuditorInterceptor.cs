using ET.BuildingBlocks.Domain;
using ET.BuildingBlocks.Infrastructure.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ET.BuildingBlocks.Infrastructure.Persistence;

public class TimeAuditorInterceptor : IDbContextInterceptor
{
    /// <inheritdoc/>
    public void BeforeSave(EntityEntry entry)
    {
        if (entry is { Entity: ICreationTimeAuditable createdEntry, State: EntityState.Added })
        {
            createdEntry.CreatedAt = DateTime.UtcNow;
        }

        if (entry is
            {
                Entity: IUpdationTimeAuditable updatedEntry,
                State: EntityState.Added or EntityState.Modified
            })
        {
            updatedEntry.UpdatedAt = DateTime.UtcNow;
        }
    }
}