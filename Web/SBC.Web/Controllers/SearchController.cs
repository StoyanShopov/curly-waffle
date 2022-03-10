namespace SBC.Web.Controllers
{
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Data.Models;
    using SBC.Services.Search;
    using SBC.Web.ViewModels.Coaches;

    public class SearchController : ApiController
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery(Name = "index")] string index, [FromQuery(Name = "id")] string id)
        {
            var result = await this.searchService.Search(index, id);
            return this.GenericResponse(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CoachSearchModel value, CancellationToken cancellationToken)
        {
            var result = await this.searchService.Create(value, cancellationToken);
            return this.GenericResponse(result);
        }
    }
}
