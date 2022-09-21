using System;
using System.Linq.Expressions;

using Microsoft.AspNetCore.Mvc;

using OSCManager.Abstractions.Model.Entities;
using OSCManager.Abstractions.Persistence;
using OSCManager.Abstractions.Persistence.Condition;

namespace OSCManager.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SourceHubController : ControllerBase
{
    private readonly ISourceHubRepository _sourceRepositoryRepository;

    public SourceHubController(ISourceHubRepository sourceRepositoryRepository)
    {
        _sourceRepositoryRepository = sourceRepositoryRepository;
    }

    [HttpGet]
    //]
    public async Task<IActionResult> PageAsync(
        [FromQuery] int? pageIndex = default,
        int? pageSize = default)
    {
        Expression<Func<SourceHub, bool>> expression = (e) => true;

        var totalCount = await _sourceRepositoryRepository.CountAsync(expression, this.HttpContext.RequestAborted);
        var paging = pageIndex == null || pageSize == null ? default : Paging.Page(pageIndex.Value, pageSize.Value);
        var items = await _sourceRepositoryRepository.FindManyAsync(expression, paging: paging, cancellationToken: this.HttpContext.RequestAborted);

        return this.Ok(items);
    }

    [HttpGet]
    public async Task<IActionResult> TestAsync()
    {
        Console.WriteLine($"ActionStart:{Thread.CurrentThread.ManagedThreadId}");
        await _sourceRepositoryRepository.TestAsync();
        Console.WriteLine($"ActionEnd:{Thread.CurrentThread.ManagedThreadId}");

        return this.Ok();
    }
}
