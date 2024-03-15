using System.Text;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using CodeCampRestora.Domain.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using CodeCampRestora.Infrastructure.Data.DbContexts;
using CodeCampRestora.Infrastructure.Identity.Models;
using CodeCampRestora.Infrastructure.Data.Interceptors;

namespace CodeCampRestora.Infrastructure;

public static class ServicesConfiguration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddIdentityCore<ApplicationUser>(
            options =>
            {
                options.User.RequireUniqueEmail = true;
            }
        )
        .AddRoles<ApplicationRole>()
        .AddRoleManager<ApplicationRoleManager>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

        var tokenValidationParameter = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            RequireExpirationTime = true,
            ValidAudience = configuration["JWT:ValidAudience"],
            ValidIssuer = configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!))
        };
        services.AddScoped(provider => tokenValidationParameter);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = tokenValidationParameter;
        });

        services.AddScoped<AuditableEntitiesInterceptor>();
        var connectionStringKey = "ProductionConnection";
        var assemblyName = Assembly.GetExecutingAssembly().FullName;
        services.AddDbContext<ApplicationDbContext>((provider, options) =>
        {
            options
                .UseNpgsql(configuration.GetConnectionString(connectionStringKey),
                    b => b.MigrationsAssembly(assemblyName))
                .AddInterceptors(provider.GetRequiredService<AuditableEntitiesInterceptor>());
        });

        return services;
    }
}