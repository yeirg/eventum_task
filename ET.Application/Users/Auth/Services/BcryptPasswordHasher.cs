using ET.Application.Users.Auth.Abstractions;

namespace ET.Application.Users.Auth.Services;

public class BcryptPasswordHasher : IPasswordHasher
{
    /// <inheritdoc/>
    public string Hash(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }

    /// <inheritdoc/>
    public bool Verify(string hash, string password)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
    }
}