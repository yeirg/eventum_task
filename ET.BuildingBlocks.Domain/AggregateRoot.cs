using ET.BuildingBlocks.Domain.DomainEvents;

namespace ET.BuildingBlocks.Domain;

public abstract class AggregateRoot<TId> : Entity<TId>, IDomainEventContainer
{
    /// <summary>
    /// Получает текущую версию корневого элемента агрегата.
    /// </summary>
    public int Version { get; protected set; }

    private readonly List<IDomainEvent> _domainEvents = [];

    /// <summary>
    /// Получает коллекцию доменных событий, связанных с этим агрегатом.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Очищает список доменных событий.
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    /// <summary>
    /// Добавляет доменное событие в список.
    /// </summary>
    /// <param name="domainEvent">Доменное событие для добавления.</param>
    protected void AddEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}

/// <summary>
/// Представляет абстрактный корневой элемент агрегата с типом идентификатора Guid.
/// Это упрощенная версия AggregateRoot{TId} с предустановленным типом идентификатора Guid.
/// </summary>
public abstract class AggregateRoot : AggregateRoot<Guid>
{
    // Так как этот класс является расширением AggregateRoot<TId> с предустановленным типом идентификатора Guid,
    // специфические методы или свойства в этом классе отсутствуют.
}