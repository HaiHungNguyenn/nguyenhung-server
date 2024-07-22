using System.Reflection;
using AutoMapper;
using NguyenHung.Common.Attributes;
using NguyenHung.DAL;
using NguyenHung.DAL.Implementations;
using NguyenHung.Service.Implementations;

namespace NguyenHung.Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterService(this IServiceCollection services)
    {
        // var assemblyNames = new []{"NguyenHung.Api","NguyenHung.Common","NguyenHung.DAL","NguyenS"} ;
        var newCateService = typeof(CategoryService);
        var registeredServiceAttribute = AppDomain.CurrentDomain.GetAssemblies()  
            .Where(assembly => assembly.GetName().Name.StartsWith("NguyenHung"))
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsClass && type.GetCustomAttributes<ServiceRegisterAttribute>().Any() && !type.IsAbstract)
            .ToList();

        foreach (var type in registeredServiceAttribute)
        {
            var attribute = type.GetCustomAttributes<ServiceRegisterAttribute>().FirstOrDefault() 
                            ?? throw new Exception("Not found ServiceRegisterAttribute");
            var lifeTimeProperty = attribute.GetType()
                .GetProperty("LifeTime", BindingFlags.NonPublic | BindingFlags.Instance)
                ?? throw new Exception("Not Found Lifetime");
            var lifeTime = lifeTimeProperty.GetValue(attribute);
            
            if (lifeTime is ServiceLifetime l)
            {
                var interfaceType = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(assembly => assembly.GetTypes())
                    .FirstOrDefault(t => type.IsAssignableTo(t) && t.IsInterface);
                
                if (interfaceType is not null)
                    services.Add(new ServiceDescriptor(interfaceType,type,l));
            }
        }

        var automapperConfig = new MapperConfiguration(config => config.AddAllProfiles());
        services.AddSingleton(automapperConfig.CreateMapper());
        return services;
    }

    public static IApplicationBuilder EnsureMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
        dbContext.Migrate();
        return app;
    }

    private static void AddAllProfiles(this IMapperConfigurationExpression configuration)
    {
        var profiles = AppDomain.CurrentDomain.GetAssemblies()
            .Where(assembly =>
            {
                var name = assembly.GetName().Name;
                return name != null && name.StartsWith("NguyenHung");
            })
            .SelectMany(assembly => assembly.GetTypes())
            .Where(t => t.IsAssignableTo(typeof(Profile)))
            .Select(t => Activator.CreateInstance(t) as Profile);
        configuration.AddProfiles(profiles);
    }
}