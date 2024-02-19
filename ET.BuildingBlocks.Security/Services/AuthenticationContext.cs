using System.Security.Claims;
using ET.BuildingBlocks.Error.Exceptions;
using ET.BuildingBlocks.Security.Abstractions;
using ET.BuildingBlocks.Security.Constants;
using Microsoft.AspNetCore.Http;

namespace ET.BuildingBlocks.Security.Services;

/// <inheritdoc/>
public class AuthenticationContext(IHttpContextAccessor httpContextAccessor) : IAuthenticationContext
{
    /// <inheritdoc/>
    public bool UserExists => httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;

    /// <inheritdoc/>
    public Guid UserId
    {
        get
        {
            if (GetCurrentUser().FindFirst(Claims.Subject) is not { } sub)
            {
                throw new ArgumentException("Missing required claims");
            }

            return Guid.Parse(sub.Value);
        }
    }

    private Claim GetCurrentUserClaim(string claimName)
    {
        return GetCurrentUser().FindFirst(claimName) ??
               throw new ArgumentException("Missing required claims");
    }

    private ClaimsPrincipal GetCurrentUser()
    {
        return httpContextAccessor.HttpContext?.User ?? throw new AppException("123", "Not authenticated");
    }
}