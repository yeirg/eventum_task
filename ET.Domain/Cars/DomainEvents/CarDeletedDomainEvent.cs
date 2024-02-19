using ET.BuildingBlocks.Domain.DomainEvents;

namespace ET.Domain.Cars.DomainEvents;

public record CarDeletedDomainEvent(Guid CarId) : DomainEvent;