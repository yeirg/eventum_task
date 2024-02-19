namespace ET.Application.Users.Auth.Abstractions;

/// <summary>
/// Предоставляет интерфейс для создания токенов.
/// </summary>
public interface ITokenFactory
{
    /// <summary>
    /// Генерирует новый токен на основе предоставленных утверждений (claims).
    /// </summary>
    /// <param name="claims">Словарь утверждений, которые будут включены в токен.</param>
    /// <returns>Строка, представляющая сгенерированный токен.</returns>
    /// <remarks>
    /// Метод должен использовать безопасный механизм генерации токенов, 
    /// чтобы гарантировать их целостность и надежность.
    /// </remarks>
    string NewToken(IDictionary<string, object> claims);
}