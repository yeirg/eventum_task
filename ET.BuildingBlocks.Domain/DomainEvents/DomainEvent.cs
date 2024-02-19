namespace ET.BuildingBlocks.Domain.DomainEvents;

public record DomainEvent : IDomainEvent
{
    /// <inheritdoc/>
    public DateTime OccuredOn { get; } = DateTime.UtcNow;
}