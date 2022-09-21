using OSCManager.Abstractions.Model.Entities;

namespace OSCManager.Abstractions.Persistence;

public interface ISourceHubRepository : IRepository<SourceHub>
{
    public Task TestAsync();
}
