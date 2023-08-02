using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DIContainer
{
    public static IServiceCollection ApplicationDependencies(this IServiceCollection services)
    {
        
        //Mapper added to container
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}