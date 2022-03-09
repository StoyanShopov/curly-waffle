namespace SBC.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Data.Models;
    using SBC.Services.Search;
    using SBC.Web.ViewModels.User;

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
        public async Task<IActionResult> Create(RegisterInputModel value)
        {
            var result = await this.searchService.Create(value);
            return this.GenericResponse(result);
        }
    }
}
