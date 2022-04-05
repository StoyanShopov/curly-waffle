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
        private readonly ApplicationDbContext applicationDbContext;
        private readonly ISearchService searchService;

        public SearchSeeder(ApplicationDbContext applicationDbContext, ISearchService searchService)
        {
            this.applicationDbContext = applicationDbContext;
            this.searchService = searchService;
        }

        public async Task SeedCourses()
        {
            var courses = await this.applicationDbContext.Courses
                                        .AsQueryable()
                                        .To<CourseSearchModel>()
                                        .ToListAsync();

            await this.searchService.CreateManyAsync("course", courses, CancellationToken.None);
        }
    }
}
