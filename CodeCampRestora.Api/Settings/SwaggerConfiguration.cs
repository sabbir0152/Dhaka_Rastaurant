using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CodeCampRestora.Api.Settings;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "CodeCampRestora",
                Description = "A .NET Core Web Api for Restaurants"
            });

            var securityScheme = new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter the token",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            };

            options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { securityScheme, Array.Empty<string>() }
            });

            options.EnableAnnotations();
        });

        return services;
    }
}