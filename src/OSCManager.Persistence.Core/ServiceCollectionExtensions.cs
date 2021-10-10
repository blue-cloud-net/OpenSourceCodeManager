using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OSCManager.Persistence.Core
{
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
            Action<IServiceProvider, DbContextOptionsBuilder> configure = null,
            bool autoRunMigrations = true)
            where TDbContext : DbContext
        {
            services.AddScoped(typeof(DbContext), typeof(TDbContext));

            services.AddDbContextPool<TDbContext>(configure);

            // TODO 注入DAL的Service
            //services
            //     .AddScoped<EntityFrameworkWorkflowDefinitionStore>()
            //     .AddScoped<EntityFrameworkWorkflowInstanceStore>()
            //     .AddScoped<EntityFrameworkWorkflowExecutionLogRecordStore>()
            //     .AddScoped<EntityFrameworkBookmarkStore>();

            return services;
        }
    }
}
