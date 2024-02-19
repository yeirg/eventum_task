using MediatR;

namespace ET.BuildingBlocks.Domain.DomainEvents;

/// <summary>
/// Интерфейс для доменных событий.
/// </summary>
public interface IDomainEvent : INotification
{
    /// <summary>
    /// Время возникновения событий.
    /// </summary>
    DateTime OccuredOn { get; }
}