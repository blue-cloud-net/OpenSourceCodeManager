using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

namespace OSCManager.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOSCMCore(this IServiceCollection services)
        {
            services.AddAutoMapper(Enumerable.Empty<Assembly>(), ServiceLifetime.Singleton);

            return services;
        }
    }
}
