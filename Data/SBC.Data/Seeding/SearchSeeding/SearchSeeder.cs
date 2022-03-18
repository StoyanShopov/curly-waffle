namespace SBC.Data.Seeding.SearchSeeding
{
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Services.Mapping;
    using SBC.Services.Search;
    using SBC.Web.ViewModels.Search;

    public class SearchSeeder
    {
        private readonly ISearchService searchService;
        private readonly ApplicationDbContext applicationDbContext;

        public SearchSeeder(ISearchService searchService, ApplicationDbContext applicationDbContext)
        {
            this.searchService = searchService;
            this.applicationDbContext = applicationDbContext;
        }

        public async Task SeedCourses()
        {
            var courses =
              await this.applicationDbContext.Courses
                        .AsQueryable()
                        .To<CourseSearchModel>()
                        .ToListAsync();
            await this.searchService.CreateMany("course", courses, CancellationToken.None);
            //foreach (var course in courses)
            //{
            //    await this.searchService.Create("course", course, CancellationToken.None);
            //}
        }
    }
}
