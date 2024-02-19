namespace ET.BuildingBlocks.Security.Abstractions;

/// <summary>
/// Предоставляет контекст аутентификации для определения идентификатора и существования пользователя
/// в текущем контексте.
/// </summary>
public interface IAuthenticationContext
{
    /// <summary>
    /// Получает значение, указывающее на то что в текущем контексте есть пользователь
    /// прошедший аутентификацию
    /// </summary>
    bool UserExists { get; }

    /// <summary>
    /// Получает идентификатор текущего пользователя.
    /// </summary>
    Guid UserId { get; }
}