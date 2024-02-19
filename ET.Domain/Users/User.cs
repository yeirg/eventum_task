using ET.BuildingBlocks.Domain;
using ET.Domain.Users.DomainEvents;

namespace ET.Domain.Users;

/// <summary>
/// Сущность, представляющая пользователя в системе.
/// </summary>
public class User : AuditableAggregateRoot
{
    private User()
    {
    }

    public User(Login login, PasswordHash passwordHash) : this(Guid.NewGuid(), login, passwordHash)
    {
    }

    public User(Guid id, Login login, PasswordHash passwordHash)
    {
        Id = id;
        // TODO: throw custom exception
        Login = login;//?? throw Errors.Administration.Validation.EmptyLogin.New();
        PasswordHash = passwordHash; //?? throw Errors.Administration.Validation.EmptyPasswordHash.New();
    }

    public Login Login { get; private set; }
    public PasswordHash PasswordHash { get; private set; }
    public bool IsDeleted { get; private set; }
    public bool IsBlocked { get; private set; }
    public DateTime? LastLoginDate { get; private set; }
    public DateTime? BlockedDate { get; private set; }
    public DateTime? DeletedDate { get; private set; }

    public void LogIn()
    {
        AddEvent(new UserLoggedInDomainEvent(Login));
        LastLoginDate = DateTime.UtcNow;
    }

    public void Block()
    {
        if (IsBlocked)
        {
            return;
        }

        IsBlocked = true;
        BlockedDate = DateTime.UtcNow;
    }
}