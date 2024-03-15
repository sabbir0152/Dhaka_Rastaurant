using CodeCampRestora.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace CodeCampRestora.Infrastructure.Identity.Interfaces;

public interface IApplicationUserManager
{
    Task<ApplicationUser?> FindByEmailAsync(string email);
    Task<ApplicationUser?> FindByIdAsync(string id);
    Task<ApplicationUser?> FindByNameAsync(string userName);
    Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
    Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
    Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role);
    Task<IList<string>> GetRolesAsync(ApplicationUser user);
}