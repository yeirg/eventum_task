using ET.BuildingBlocks.Domain.DomainEvents;

namespace ET.Domain.Cars.DomainEvents;

public record CarUpdatedDomainEvent(Guid CarId, string Brand, string Model, string Color) : DomainEvent;