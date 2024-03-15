using Microsoft.Extensions.DependencyInjection;

namespace CodeCampRestora.Application.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class SingletonLifeTimeAttribute : Attribute
{
    public static ServiceLifetime LifeTime => ServiceLifetime.Singleton;
}