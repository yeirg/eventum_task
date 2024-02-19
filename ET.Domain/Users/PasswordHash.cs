using ET.BuildingBlocks.Domain;

namespace ET.Domain.Users;

/// <summary>
/// Значимый объект, представляющий хэш пароля пользователя.
/// </summary>
public class PasswordHash : ValueObject
{
    private readonly string _value;

    public PasswordHash()
    {
        
    }
    
    public PasswordHash(string value)
    {
        Value = value;
    }

    public string Value
    {
        get => _value;
        private init
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                // TODO: throw custom exception
                //throw Errors.Administration.Validation.EmptyPasswordHash.New();
            }

            _value = value;
        }
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator string(PasswordHash login)
    {
        return login.Value;
    }

    public static implicit operator PasswordHash(string login)
    {
        return new PasswordHash(login);
    }
}