using ET.BuildingBlocks.Domain.DomainEvents;

namespace ET.Domain.Cars.DomainEvents;

public record CarCreatedDomainEvent(Guid Id, string Brand, string Model, string Color) : DomainEvent;