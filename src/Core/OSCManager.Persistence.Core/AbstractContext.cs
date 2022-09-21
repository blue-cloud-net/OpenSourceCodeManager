namespace OSCManager.Persistence.Core;

public abstract class AbstractContext<TDbContext> : DbContext where TDbContext : DbContext
{
    public const string Schema = "OSCM";

    public const int DefaultMaxStringLength = 4000;

    public AbstractContext(DbContextOptions<TDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (!String.IsNullOrWhiteSpace(Schema))
        {
            modelBuilder.HasDefaultSchema(Schema);
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntity).Assembly);
    }
}
