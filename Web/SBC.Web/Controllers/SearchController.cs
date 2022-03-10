namespace SBC.Web.Controllers
{
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Search;
    using SBC.Web.ViewModels.Search;

    public class SearchController : ApiController
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet]
        public async Task<IActionResult> Search(
                                                [FromQuery(Name = "index")] string index,
                                                [FromQuery(Name = "field")] string field,
                                                [FromQuery(Name = "value")] string value,
                                                [FromQuery(Name = "size")] int? size,
                                                [FromQuery(Name = "sort")] string sort,
                                                CancellationToken cancellationToken)
        {
            var result = await this.searchService.Search(index, field, value, size != null ? (int)size : 20, sort, cancellationToken);
            return this.GenericResponse(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
                                                [FromQuery(Name = "index")] string index,
                                                SearchModel value,
                                                CancellationToken cancellationToken)
        {
            var result = await this.searchService.Create(index, value, cancellationToken);
            return this.GenericResponse(result);
        }
    }
}
