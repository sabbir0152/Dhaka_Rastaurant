using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Infrastructure.Constants;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Infrastructure.Identity.Services;

[ScopedLifetime]
public class CurrentUserService : ICurrentUserService
{
    private readonly HttpContext _httpContext;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContext = httpContextAccessor.HttpContext ?? new DefaultHttpContext();
    }

    public string UserId => _httpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid) ?? string.Empty;
    public string RestaurantId => _httpContext.User.FindFirstValue(ApplicationConstants.RestaurantIdClaim) ?? string.Empty;
    public bool IsInRole(string role) => _httpContext.User.IsInRole(role);
}