using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using OSCManager.Abstractions.Model;
using OSCManager.Abstractions.Model.Entities;
using OSCManager.Abstractions.Persistence;

using Swashbuckle.AspNetCore.Annotations;

namespace OSCManager.Api.Controllers
{
    [ApiController]
    public class SourceRepositoryController : Controller
    {
        private readonly ISourceRepositoryRepository _sourceRepositoryRepository;

        public SourceRepositoryController(ISourceRepositoryRepository sourceRepositoryRepository)
        {
            _sourceRepositoryRepository = sourceRepositoryRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SourceRepository>))]
        [SwaggerOperation(
            Summary = "Returns all available activities.",
            Description = "Returns all available activities from which workflow definitions can be built.",
            OperationId = "Activities.List",
            Tags = new[] { "Activities" })
        ]
        public async Task<IActionResult> List(
            [FromQuery] int? page = default,
            int? pageSize = default,
            CancellationToken cancellationToken = default)
        {
            Expression<Func<SourceRepository, bool>> expression = (e) => true;

            var totalCount = await _sourceRepositoryRepository.CountAsync(expression, cancellationToken);
            var paging = page == null || pageSize == null ? default : Paging.Page(page.Value, pageSize.Value);
            var items = await _sourceRepositoryRepository.FindManyAsync(expression, paging: paging, cancellationToken: cancellationToken);

            return Json(items);
        }
    }
}
