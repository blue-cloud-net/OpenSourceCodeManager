using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

using Microsoft.Extensions.Logging;

using OSCManager.Abstractions.Model.Entities;

namespace OSCManager.Core.Services;

public class SourceHubService : ISourceHubService
{
    private readonly ILogger<SourceHubService> _logger;
    private readonly ISourceHubRepository _sourceHubRepository;

    public SourceHubService(
        ILogger<SourceHubService> logger,
        ISourceHubRepository sourceHubRepository)
    {
        _logger = logger;
        _sourceHubRepository = sourceHubRepository;
    }

    public async Task<OperationalResult<SourceHub>> AddAsync(
        SourceHub sourceHub, CancellationToken cancellationToken = default)
    {
        try
        {
            await _sourceHubRepository.AddAsync(sourceHub, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError("Add Error!", e);

            return OperationalResult<SourceHub>.Error(e);
        }

        return OperationalResult<SourceHub>.OK(sourceHub);
    }

    public async Task<OperationalResult> DeleteByIdAsync(
        string id, CancellationToken cancellationToken = default)
    {
        try
        {
            await _sourceHubRepository.DeleteAsync(new() { Id = id }, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError("Delete Error!", e);

            return OperationalResult.Error(e);
        }

        return OperationalResult.OK();
    }

    public async Task<OperationalResult<SourceHub>> GetByIdAsync(
        string id, CancellationToken cancellationToken = default)
    {
        var entry = await _sourceHubRepository.FindAsync(p => p.Id == id, cancellationToken);

        if (entry is null)
        {
            return OperationalResult<SourceHub>.Failed("Not Found!");
        }

        return OperationalResult<SourceHub>.OK(entry);
    }

    public async Task<PageResult<SourceHub>> GetPageAsync(
        SourceHubSearchModel searchModel, Paging paging, CancellationToken cancellationToken = default)
    {
        Expression<Func<SourceHub, bool>> expression = p => true;

        var count = await _sourceHubRepository.CountAsync(expression, cancellationToken);

        if (count == 0 || count <= paging.Skip)
        {
            return PageResult<SourceHub>.OK(paging);
        }

        var entries = await _sourceHubRepository.FindManyAsync(expression, paging, cancellationToken: cancellationToken);

        return PageResult<SourceHub>.OK(entries, paging, count);
    }

    public Task<OperationalResult> UpdateAsync(
        SourceHub sourceHub, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
