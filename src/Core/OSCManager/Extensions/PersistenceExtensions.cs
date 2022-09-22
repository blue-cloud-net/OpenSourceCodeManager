using OSCManager.Persistence.MySql;

namespace OSCManager.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        return services.
            AddMySqlDatabase(configuration);
    }
}
