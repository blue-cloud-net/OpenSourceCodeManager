using OSCManager.Abstractions.Model.Entities;

namespace OSCManager.Abstractions.Services;

public interface ISourceHubService
{
    Task<OperationalResult<SourceHub>> AddAsync(SourceHub sourceHub, CancellationToken cancellationToken = default);
    Task<OperationalResult> DeleteAsync(SourceHub sourceHub, CancellationToken cancellationToken = default);
    Task<OperationalResult> UpdateAsync(SourceHub sourceHub, CancellationToken cancellationToken = default);
    Task<OperationalResult<SourceHub>> GetAsync(SourceHub sourceHub, CancellationToken cancellationToken = default);
}
