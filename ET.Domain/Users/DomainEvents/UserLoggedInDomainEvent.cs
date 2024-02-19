using ET.BuildingBlocks.Domain.DomainEvents;

namespace ET.Domain.Users.DomainEvents;

/// <summary>
/// Событие домена, представляющее вход пользователя в систему.
/// </summary>
public record UserLoggedInDomainEvent(string Login) : DomainEvent;
