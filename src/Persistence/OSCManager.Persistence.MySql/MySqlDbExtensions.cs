using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using OSCManager.Abstractions.Model;
using OSCManager.Persistence.Core;

namespace OSCManager.Persistence.MySql;

public static class MySqlDbExtensions
{
    public static IServiceCollection AddMySqlDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        return services.UseEntityFrameworkPersistence<MySqlDbContext>(configuration, (provider, options) =>
        {
            var databaseOptions = provider.GetRequiredService<DatabaseOptions>();

            options.UseMySQL(databaseOptions.ConnectionString);
        });
    }
}
