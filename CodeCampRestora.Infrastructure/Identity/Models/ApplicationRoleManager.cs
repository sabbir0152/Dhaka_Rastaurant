using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Infrastructure.Identity.Interfaces;

namespace CodeCampRestora.Infrastructure.Identity.Models;

[ScopedLifetime]
public class ApplicationRoleManager : RoleManager<ApplicationRole>, IApplicationRoleManager
{
    public ApplicationRoleManager(
        IRoleStore<ApplicationRole> store,
        IEnumerable<IRoleValidator<ApplicationRole>> roleValidators,
        ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors,
        ILogger<RoleManager<ApplicationRole>> logger)
        : base(store, roleValidators, keyNormalizer, errors, logger)
    {
    }
}