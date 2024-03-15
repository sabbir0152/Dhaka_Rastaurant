using Microsoft.Extensions.DependencyInjection;

namespace CodeCampRestora.Application.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class TransientLifeTimeAttribute : Attribute
{
    public static ServiceLifetime LifeTime => ServiceLifetime.Transient;
}