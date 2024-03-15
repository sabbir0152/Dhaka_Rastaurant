using CodeCampRestora.Infrastructure.Identity.Models;

namespace CodeCampRestora.Infrastructure.Identity.Interfaces;

public interface IApplicationRoleManagerAdapter
{
    Task<ApplicationRole?> FindByNameAsync(string roleName);
}