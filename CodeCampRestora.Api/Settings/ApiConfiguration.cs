using WebApi.Middlewares;

namespace CodeCampRestora.Api.Settings;

public static class ApiConfiguration
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddHttpContextAccessor();

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy =>
                {
                    policy.WithOrigins(
                       "http://localhost:3000",
                       "http://localhost:3001",
                       "http://localhost:3002"
                   )
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
        });

        return services;
    }

    public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlerMiddleware>();
    }
}