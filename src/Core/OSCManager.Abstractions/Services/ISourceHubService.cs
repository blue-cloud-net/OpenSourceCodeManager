using OSCManager.Abstractions.Model.Entities;
using OSCManager.Abstractions.Model.SearchModel;

namespace OSCManager.Abstractions.Services;

public interface ISourceHubService
{
    Task<OperationalResult<SourceHub>> AddAsync(SourceHub sourceHub, CancellationToken cancellationToken = default);
    Task<OperationalResult> DeleteByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<OperationalResult> UpdateAsync(SourceHub sourceHub, CancellationToken cancellationToken = default);
    Task<OperationalResult<SourceHub>> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<PageResult<SourceHub>> GetPageAsync(SourceHubSearchModel searchModel, Paging paging, CancellationToken cancellationToken = default);
}
