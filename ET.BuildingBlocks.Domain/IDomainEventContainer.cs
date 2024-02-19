using ET.BuildingBlocks.Domain.DomainEvents;

namespace ET.BuildingBlocks.Domain;

public interface IDomainEventContainer
{
    /// <summary>
    /// Получает коллекцию доменных событий.
    /// </summary>
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    /// <summary>
    /// Очищает коллекцию доменных событий.
    /// </summary>
    void ClearDomainEvents();
}
