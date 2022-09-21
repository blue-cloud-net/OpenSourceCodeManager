using Microsoft.Extensions.DependencyInjection;

namespace OSCManager.Api;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddApiEndpoints(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddRouting(options => { options.LowercaseUrls = true; });

        return services;
    }
}