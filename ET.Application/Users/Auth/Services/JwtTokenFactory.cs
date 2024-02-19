using ET.Application.Users.Auth.Abstractions;
using ET.BuildingBlocks.Security.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.JsonWebTokens;

namespace ET.Application.Users.Auth.Services;

public class JwtTokenFactory(IOptions<JwtTokenOptions> options) : ITokenFactory
{
    private readonly JwtTokenOptions _options = options.Value;
    private readonly JsonWebTokenHandler _tokenHandler = new();

    /// <inheritdoc/>
    public string NewToken(IDictionary<string, object> claims)
    {
        var signingCredentials = new SigningCredentials(
            _options.CreateKey(),
            SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Claims = claims,
            Issuer = _options.Issuer,
            Audience = _options.Audience,
            NotBefore = DateTime.UtcNow,
            Expires = DateTime.UtcNow.Add(_options.TokenLifetime),
            SigningCredentials = signingCredentials,
        };

        return _tokenHandler.CreateToken(tokenDescriptor);
    }
}