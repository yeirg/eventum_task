using ET.BuildingBlocks.Domain;
using ET.BuildingBlocks.Infrastructure.Persistence.Abstractions;
using ET.BuildingBlocks.Security.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ET.BuildingBlocks.Infrastructure.Persistence;

public class ActorAuditorInterceptor : IDbContextInterceptor
{
    private readonly IAuthenticationContext _authenticationContext;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ActorAuditorInterceptor"/> с заданным контекстом аутентификации и контекстом базы данных.
    /// </summary>
    /// <param name="authenticationContext">Контекст аутентификации, содержащий информацию о текущем пользователе.</param>
    public ActorAuditorInterceptor(IAuthenticationContext authenticationContext)
    {
        _authenticationContext = authenticationContext;
    }

    /// <inheritdoc/>
    public void BeforeSave(EntityEntry entry)
    {
        if (!_authenticationContext.UserExists)
        {
            return;
        }

        var currentUserId = _authenticationContext.UserId;

        if (entry is { Entity: ICreationActorAuditable createdEntry, State: EntityState.Added })
        {
            createdEntry.CreatedBy = currentUserId;
        }

        if (entry is { Entity: IUpdationActorAuditable updatedEntry, State: EntityState.Added or EntityState.Modified })
        {
            updatedEntry.UpdatedBy = currentUserId;
        }
    }
}