using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace ET.BuildingBlocks.Security.Options;

/// <summary>
/// Опции для создания и валидации JWT-токенов.
/// </summary>
public class JwtTokenOptions
{
    /// <summary>
    /// Конструктор с параметрами для создания объекта JwtTokenOptions.
    /// </summary>
    /// <param name="issuer">Эмитент токена.</param>
    /// <param name="audience">Получатель токена.</param>
    /// <param name="tokenLifetime">Время жизни токена.</param>
    /// <param name="secretKey">Секретный ключ для подписи токена.</param>
    public JwtTokenOptions(string issuer, string audience, TimeSpan tokenLifetime, string secretKey)
    {
        Issuer = issuer;
        Audience = audience;
        TokenLifetime = tokenLifetime;
        SecretKey = secretKey;
    }

    public JwtTokenOptions()
    {
        
    }

    /// <summary>
    /// Эмитент токена.
    /// </summary>
    public string Issuer { get; set; }
    
    /// <summary>
    /// Получатель токена.
    /// </summary>
    public string Audience { get; set; }
    
    /// <summary>
    /// Время жизни токена.
    /// </summary>
    public TimeSpan TokenLifetime { get; set; }
    
    /// <summary>
    /// Секретный ключ для подписи токена.
    /// </summary>
    public string SecretKey { get; set; }

    /// <summary>
    /// Создает ключ безопасности на основе секретного ключа.
    /// </summary>
    /// <returns>SymmetricSecurityKey на основе секретного ключа.</returns>
    public SymmetricSecurityKey CreateKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
    }
}