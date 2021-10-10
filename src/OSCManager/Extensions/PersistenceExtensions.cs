using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using OSCManager.Persistence.MySql;

namespace OSCManager.Extensions
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            return services.
                  AddMySqlDatabase()
                  ;
        }
    }
}
