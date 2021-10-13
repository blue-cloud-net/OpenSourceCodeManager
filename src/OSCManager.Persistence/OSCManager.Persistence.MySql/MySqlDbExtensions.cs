using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using OSCManager.Abstractions.Options;
using OSCManager.Persistence.Core;

namespace OSCManager.Persistence.MySql
{
    public static class MySqlDbExtensions
    {
        public static IServiceCollection AddMySqlDatabase(this IServiceCollection services)
        {
           return services.UseEntityFrameworkPersistence<MySqlDbContext>( (provider, options) =>
            {
                var databaseOptions = provider.GetRequiredService<IOptionsSnapshot<DatabaseOptions>>();

                options.UseMySQL(databaseOptions.Value.ConnectionString);
            });
        }
    }
}
