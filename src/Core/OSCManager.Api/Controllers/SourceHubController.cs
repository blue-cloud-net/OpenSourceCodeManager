using Microsoft.AspNetCore.Mvc;

using OSCManager.Abstractions.Model.Entities;
using OSCManager.Abstractions.Services;

namespace OSCManager.Api.Controllers;

[ApiController]
[Route("api/")]
public class SourceHubController : ControllerBase
{
    private readonly ISourceHubService _sourceHubService;

    public SourceHubController(
        ISourceHubService sourceHubService)
    {
        _sourceHubService = sourceHubService;
    }

    [HttpPost]
    [Route("[controller]")]
    public Task<OperationalResult<SourceHub>> AddAsync(
        [FromBody] SourceHub sourceHub)
    {
        return _sourceHubService.AddAsync(sourceHub, this.HttpContext.RequestAborted);
    }

    [HttpDelete]
    [Route("[controller]/{id}")]
    public Task<OperationalResult> DeleteAsync(
        [FromRoute] string id)
    {
        return _sourceHubService.DeleteByIdAsync(id, this.HttpContext.RequestAborted);
    }

    [HttpPut]
    [Route("[controller]")]
    public Task<OperationalResult> UpdateAsync(
        [FromBody] SourceHub sourceHub)
    {
        return _sourceHubService.UpdateAsync(sourceHub, this.HttpContext.RequestAborted);
    }

    [HttpGet]
    [Route("[controller]/{id}")]
    public Task<OperationalResult<SourceHub>> GetAsync(
        [FromRoute] string id)
    {
        return _sourceHubService.GetByIdAsync(id, this.HttpContext.RequestAborted);
    }

    [HttpGet]
    [Route("[controller]")]
    public Task<PageResult<SourceHub>> PageAsync(
        [FromQuery] int? pageIndex = default,
        int? pageSize = default)
    {
        return _sourceHubService.GetPageAsync(new(), Paging.Page(pageIndex, pageSize), this.HttpContext.RequestAborted);
    }
}
