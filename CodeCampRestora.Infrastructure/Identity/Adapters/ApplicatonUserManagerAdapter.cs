using Microsoft.AspNetCore.Identity;
using CodeCampRestora.Domain.Identity;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Infrastructure.Identity.Interfaces;

namespace CodeCampRestora.Infrastructure.Identity.Adapters;

[ScopedLifetime]
public class ApplicationUserManagerAdapter : IApplicationUserManagerAdapter
{
    private readonly IApplicationUserManager _applicationUserManager;

    public ApplicationUserManagerAdapter(IApplicationUserManager applicatonUserManager)
    {
        _applicationUserManager = applicatonUserManager;
    }

    public async Task<ApplicationUser?> FindByEmailAsync(string email)
    {
        return await _applicationUserManager.FindByEmailAsync(email);
    }

    public async Task<ApplicationUser?> FindByIdAsync(string email)
    {
        return await _applicationUserManager.FindByIdAsync(email);
    }

    public async Task<ApplicationUser?> FindByNameAsync(string userName)
    {
        return await _applicationUserManager.FindByNameAsync(userName);
    }

    public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
    {
        return await _applicationUserManager.CheckPasswordAsync(user, password);
    }

    public async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
    {
        return await _applicationUserManager.CreateAsync(user, password);
    }

    public async Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role)
    {
        return await _applicationUserManager.AddToRoleAsync(user, role);
    }

    public async Task<IList<string>> GetRolesAsync(ApplicationUser user)
    {
        return await _applicationUserManager.GetRolesAsync(user);
    }
}