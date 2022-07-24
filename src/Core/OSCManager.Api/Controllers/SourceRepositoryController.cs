using System.Linq.Expressions;

using Microsoft.AspNetCore.Mvc;

using OSCManager.Abstractions.Model.Entities;
using OSCManager.Abstractions.Persistence;
using OSCManager.Abstractions.Persistence.Condition;

namespace OSCManager.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SourceRepositoryController : Controller
{
    private readonly ISourceHubRepository _sourceRepositoryRepository;

    public SourceRepositoryController(ISourceHubRepository sourceRepositoryRepository)
    {
        _sourceRepositoryRepository = sourceRepositoryRepository;
    }

    [HttpGet]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SourceRepository>))]
    //[SwaggerOperation(
    //    Summary = "Returns all available activities.",
    //    Description = "Returns all available activities from which workflow definitions can be built.",
    //    OperationId = "Activities.List",
    //    Tags = new[] { "Activities" })
    //]
    public async Task<IActionResult> List(
        [FromQuery] int? page = default,
        int? pageSize = default,
        CancellationToken cancellationToken = default)
    {
        Expression<Func<SourceHub, bool>> expression = (e) => true;

        var totalCount = await _sourceRepositoryRepository.CountAsync(expression, cancellationToken);
        var paging = page == null || pageSize == null ? default : Paging.Page(page.Value, pageSize.Value);
        var items = await _sourceRepositoryRepository.FindManyAsync(expression, paging: paging, cancellationToken: cancellationToken);

        return this.Json(items);
    }
}
