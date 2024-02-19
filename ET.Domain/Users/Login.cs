using ET.BuildingBlocks.Domain;

namespace ET.Domain.Users;

/// <summary>
/// Значимый объект, представляющий логин пользователя.
/// </summary>
public class Login : ValueObject
{
    private readonly string _value;

    private Login()
    {
        
    }
    
    public Login(string value)
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
                //throw Errors.Administration.Validation.EmptyLogin.New();
            }
            _value = value;
        }
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator string(Login login) => login.Value;
    public static implicit operator Login(string login) => new Login(login);
}
