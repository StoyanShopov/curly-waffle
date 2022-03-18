namespace SBC.Web.Controllers
{
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Data.Seeding.SearchSeeding;
    using SBC.Services.Search;
    using SBC.Web.ViewModels.Search;

    public class SearchController : ApiController
    {
        private readonly ISearchService searchService;
        private readonly SearchSeeder seederService;

        public SearchController(ISearchService searchService, SearchSeeder seederService)
        {
            this.searchService = searchService;
            this.seederService = seederService;
        }

        // This endpoints is only for demo
        // To setup ElasticSearch do:
        // First download https://artifacts.elastic.co/downloads/elasticsearch/elasticsearch-7.8.1-windows-x86_64.zip
        // Next Unzip, Start ../bin/elasticsearch.bat
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
                                                CourseSearchModel value,
                                                CancellationToken cancellationToken)
        {
            var result = await this.searchService.Create(index, value, cancellationToken);
            return this.GenericResponse(result);
        }

        [HttpPost("seed")]
        public async Task<IActionResult> Seed()
        {
            await this.seederService.SeedCourses();

            return this.GenericResponse(true);
        }
    }
}
