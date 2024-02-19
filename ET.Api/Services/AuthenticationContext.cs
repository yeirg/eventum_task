using System.Security.Claims;
using ET.BuildingBlocks.Security.Abstractions;
using ET.BuildingBlocks.Security.Constants;

namespace ET.Api.Services;

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
                // TODO: implement
                throw new Exception();
                //throw Errors.Security.Auth.MissingRequiredClaims.New(Guid.Empty, Claims.Subject.YieldArray());
            }

            return Guid.Parse(sub.Value);
        }
    }

    private Claim GetCurrentUserClaim(string claimName)
    {
        return GetCurrentUser().FindFirst(claimName) ?? throw new Exception();
        // TODO: Implement this method
        // throw Errors.Security.Auth.MissingRequiredClaims.New(UserId, claimName.YieldArray());
    }

    private ClaimsPrincipal GetCurrentUser()
    {
        return httpContextAccessor.HttpContext?.User ?? throw new Exception();
        // TODO: throw exception
        // ?? throw Errors.Security.Auth.NotAuthenticated.New();
    }
}