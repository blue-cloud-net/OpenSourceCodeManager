namespace OSCManager.Persistence.Core.Repository;

public class SourceHubRepository : BaseRepository<SourceHub>, ISourceHubRepository
{
    public SourceHubRepository(
        DbContext context, IMapper mapper, ILogger<SourceHubRepository> logger) : base(context, mapper, logger)
    {
    }

    public async Task TestAsync()
    {
        Console.WriteLine($"RepositoryStart:{Thread.CurrentThread.ManagedThreadId}");
        await Task.Delay(1000);
        Console.WriteLine($"RepositoryEnd:{Thread.CurrentThread.ManagedThreadId}");
    }
}
