using Microsoft.Extensions.DependencyInjection;

namespace CodeCampRestora.Application.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class ScopedLifetimeAttribute : Attribute
{
    public static ServiceLifetime LifeTime => ServiceLifetime.Scoped;
}