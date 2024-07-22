
using Microsoft.Extensions.DependencyInjection;

namespace NguyenHung.Common.Attributes;

public class ServiceRegisterAttribute: System.Attribute
{
    private ServiceLifetime LifeTime { get; set; }

    public ServiceRegisterAttribute(ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        LifeTime = lifetime;
    }
}