using ET.Application.Users.Auth.Services;
using ET.BuildingBlocks.Application.Mediator;
using MediatR;

namespace ET.Application.Users.Auth.UseCases;

public class LoginUseCase : UseCase<LoginRequest, string>
{
    private readonly AuthenticationService _authenticationService;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="LoginUseCase"/>.
    /// </summary>
    /// <param name="eventPublishQueue">Очередь для публикации событий.</param>
    /// <param name="authenticationService">Сервис аутентификации для обработки запросов на вход.</param>
    public LoginUseCase(
        AuthenticationService authenticationService) : base()
    {
        _authenticationService = authenticationService;
    }

    /// <summary>
    /// Обрабатывает запрос на вход в систему.
    /// </summary>
    /// <param name="request">Данные запроса на вход.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    /// <returns>Токен доступа.</returns>
    protected override async Task<string> HandleAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        return await _authenticationService.Login(request.Login!, request.Password!);
    }
}

/// <summary>
/// Запрос данных для входа в систему.
/// </summary>
public class LoginRequest : IRequest<string>
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="LoginRequest"/>.
    /// </summary>
    /// <param name="login">Логин пользователя.</param>
    /// <param name="password">Пароль пользователя.</param>
    public LoginRequest(string? login, string? password)
    {
        Login = login;
        Password = password;
    }
    
    /// <summary>
    /// Логин пользователя.
    /// </summary>
    public string? Login { get; set; }

    /// <summary>
    /// Пароль пользователя.
    /// </summary>
    public string? Password { get; set; }
}

