using CodeCampRestora.Infrastructure.Identity.Models;

namespace CodeCampRestora.Infrastructure.Identity.Interfaces;

public interface IApplicationRoleManager
{
    Task<ApplicationRole?> FindByNameAsync(string roleName);
}