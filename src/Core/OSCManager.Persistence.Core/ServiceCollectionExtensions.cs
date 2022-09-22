using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using OSCManager.Abstractions.Model;
using OSCManager.Persistence.Core.Repository;

namespace OSCManager.Persistence.Core;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configures to use Entity Framework Core for persistence, using pooled DB Context instances.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Pooled DB Context instances is a performance optimisation which is documented in more detail at
    /// https://docs.microsoft.com/en-us/ef/core/performance/advanced-performance-topics?tabs=with-constant#dbcontext-pooling.
    /// </para>
    /// </remarks>
    /// <param name="elsa">An Elsa options builder</param>
    /// <param name="configure">A configuration builder callback</param>
    /// <param name="autoRunMigrations">If <c>true</c> then database migrations will be auto-executed on startup</param>
    /// <returns>The Elsa options builder, so calls may be chained</returns>
    public static IServiceCollection UseEntityFrameworkPersistence<TDbContext>(this IServiceCollection services,
        IConfiguration configuration,
        Action<IServiceProvider, DbContextOptionsBuilder>? configure = null,
        bool autoRunMigrations = true)
        where TDbContext : DbContext
    {
        services.AddScoped(typeof(DbContext), typeof(TDbContext));

        services.AddDbContextPool<TDbContext>(configure);

        services.AddSingleton<DatabaseOptions>(servicesProvider =>
        {
            var options = new DatabaseOptions();
            configuration.Bind(DatabaseOptions.Position, options);
            return options;
        });

        // TODO 注入DAL的Service
        services
            .AddScoped(typeof(ISourceHubRepository), typeof(SourceHubRepository));

        return services;
    }
}
