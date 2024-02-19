using ET.Application.Users.Auth.Abstractions;
using ET.BuildingBlocks.Application.Consistence.Abstractions;
using ET.BuildingBlocks.Security.Constants;
using ET.Domain.Users.Persistence;
using ET.Domain.Users.Specifications;

namespace ET.Application.Users.Auth.Services;

/// <summary>
/// Сервис, предоставляющий функциональность для аутентификации пользователей.
/// </summary>
public class AuthenticationService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;
    private readonly ITokenFactory _tokenFactory;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="AuthenticationService"/>.
    /// </summary>
    /// <param name="passwordHasher">Хэшер паролей для проверки паролей пользователей.</param>
    /// <param name="userRepository">Репозиторий для доступа к данным пользователей.</param>
    /// <param name="tokenFactory">Фабрика для создания токенов доступа.</param>
    /// <param name="unitOfWork">Единица работы для управления транзакциями.</param>
    public AuthenticationService(
        IPasswordHasher passwordHasher,
        IUserRepository userRepository,
        ITokenFactory tokenFactory,
        IUnitOfWork unitOfWork)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _tokenFactory = tokenFactory;
        _unitOfWork = unitOfWork;
    }
    
    /// <summary>
    /// Асинхронно осуществляет вход пользователя в систему.
    /// </summary>
    /// <param name="login">Логин пользователя.</param>
    /// <param name="password">Пароль пользователя.</param>
    /// <returns>Токен доступа для аутентифицированного пользователя.</returns>
    /// <exception cref="BusinessException">Выбрасывается, если учетные данные неверны.</exception>
    public async Task<string> Login(string login, string password)
    {
        var user = await _userRepository.GetFirstOrDefaultAsync(
            new UserSpecification()
                .ByLogin(login));

        if (user is null || !_passwordHasher.Verify(user.PasswordHash, password))
        {
            // TODO: Add CHECKING FOR USER EXISTENCE
            throw new ArgumentException("Invalid credentials.");
            //throw Errors.Administration.Business.InvalidCredentials.New();
        }
        
        var claims = new Dictionary<string, object>
        {
            [Claims.Subject] = user.Id.ToString(),
        };

        var newToken = _tokenFactory.NewToken(claims); 
        
        user.LogIn();
        await _unitOfWork.CommitAsync();
        
        return newToken;
    }
}