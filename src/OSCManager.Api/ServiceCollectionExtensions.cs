using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

namespace OSCManager.Api
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddApiEndpoints(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddRouting(options => { options.LowercaseUrls = true; });

            return services;
        }
    }
}
