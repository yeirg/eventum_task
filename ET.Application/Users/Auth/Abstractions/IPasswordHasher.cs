namespace ET.Application.Users.Auth.Abstractions;

/// <summary>
/// Предоставляет интерфейс для хэширования и проверки паролей.
/// </summary>
public interface IPasswordHasher
{
    /// <summary>
    /// Создает хэш пароля.
    /// </summary>
    /// <param name="password">Исходный пароль для хэширования.</param>
    /// <returns>Хэш пароля.</returns>
    /// <remarks>
    /// Метод должен использовать надежный алгоритм хэширования, чтобы обеспечить безопасность паролей.
    /// </remarks>
    string Hash(string password);

    /// <summary>
    /// Проверяет соответствие пароля и его хэша.
    /// </summary>
    /// <param name="hash">Хэш пароля.</param>
    /// <param name="password">Исходный пароль для проверки.</param>
    /// <returns>True, если хэш соответствует паролю, иначе false.</returns>
    /// <remarks>
    /// Метод должен корректно обрабатывать ситуации, когда пароль или хэш не соответствуют друг другу.
    /// </remarks>
    bool Verify(string hash, string password);
}