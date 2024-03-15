using FluentValidation;
using System.Reflection;
using CodeCampRestora.Application.Attributes;
using Microsoft.Extensions.DependencyInjection;
using CodeCampRestora.Application.Common.Behaviors;


namespace CodeCampRestora.Application;

public static class ServicesConfiguration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var currentExecutingAssembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg =>
        {
            cfg.Lifetime = ServiceLifetime.Scoped;
            cfg.RegisterServicesFromAssembly(currentExecutingAssembly);
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(currentExecutingAssembly);

        services
            .AddServices(typeof(ScopedLifetimeAttribute))
            .AddServices(typeof(TransientLifeTimeAttribute))
            .AddServices(typeof(SingletonLifeTimeAttribute));

        MapsterConfig.AddMapsterConfig();

        return services;
    }

    private static IServiceCollection AddServices(
        this IServiceCollection services,
        Type attributeType)
    {
        var lifetime = GetLifeTimeFrom(attributeType);
        bool hasAttribute(Type type) => type.IsClass && !type.IsAbstract && type.IsDefined(attributeType, false);

        var typesWithLifetimeAttribute = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(hasAttribute)
            .ToList();

        typesWithLifetimeAttribute.ForEach(concreteType => {
            var interfaceName = $"I{concreteType.Name}";
            var serviceType = concreteType.GetInterface(interfaceName);
            serviceType ??= concreteType;

            services.Inject(
                lifetime,
                serviceType: serviceType,
                implementationType: concreteType
            );
        });

        return services;
    }

    private static ServiceLifetime GetLifeTimeFrom(Type attributeType)
    {
        var propertyNameToDetermineLifetime = "LifeTime";
        var property = attributeType.GetProperty(propertyNameToDetermineLifetime)
            ?? throw new NullReferenceException($"{propertyNameToDetermineLifetime} is not specified.");
        var lifetime = (ServiceLifetime) property.GetValue(propertyNameToDetermineLifetime)!;

        return lifetime;
    }

    private static void Inject(
        this IServiceCollection services,
        ServiceLifetime lifetime,
        Type serviceType,
        Type implementationType)
    {
        _ = lifetime switch
        {
            ServiceLifetime.Scoped => services.AddScoped(serviceType, implementationType),
            ServiceLifetime.Transient => services.AddTransient(serviceType, implementationType),
            ServiceLifetime.Singleton => services.AddSingleton(serviceType, implementationType),
            _ => throw new ArgumentException("Invalid Lifetime")
        };
    }
}