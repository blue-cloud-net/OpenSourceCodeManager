using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

namespace OSCManager.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOSCMCore(this IServiceCollection services)
    {
        services.AddAutoMapper(Enumerable.Empty<Assembly>(), ServiceLifetime.Singleton);

        return services;
    }
}
