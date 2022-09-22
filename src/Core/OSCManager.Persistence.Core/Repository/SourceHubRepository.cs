namespace OSCManager.Persistence.Core.Repository;

public class SourceHubRepository : BaseRepository<SourceHub>, ISourceHubRepository
{
    public SourceHubRepository(
        DbContext context, IMapper mapper, ILogger<SourceHubRepository> logger) : base(context, mapper, logger)
    {
    }
}
