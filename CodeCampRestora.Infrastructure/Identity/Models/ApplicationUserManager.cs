using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using CodeCampRestora.Domain.Identity;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Infrastructure.Identity.Interfaces;

namespace CodeCampRestora.Infrastructure.Identity.Models;

[ScopedLifetime]
public class ApplicationUserManager : UserManager<ApplicationUser>, IApplicationUserManager
{
    public ApplicationUserManager(
        IUserStore<ApplicationUser> store,
        IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<ApplicationUser> passwordHasher,
        IEnumerable<IUserValidator<ApplicationUser>> userValidators,
        IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
        ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors,
        IServiceProvider services,
        ILogger<UserManager<ApplicationUser>> logger)
        : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
    }
}