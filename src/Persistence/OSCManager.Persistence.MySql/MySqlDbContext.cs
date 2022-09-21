using Microsoft.EntityFrameworkCore;

using OSCManager.Persistence.Core;

namespace OSCManager.Persistence.MySql;

public class MySqlDbContext : AbstractContext<MySqlDbContext>
{
    public MySqlDbContext(DbContextOptions<MySqlDbContext> options)
        : base(options)
    { }
}
