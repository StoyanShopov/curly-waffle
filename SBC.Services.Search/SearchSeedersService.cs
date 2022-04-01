namespace SBC.Services.Search
{
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Mapping;
    using SBC.Web.ViewModels.Search;

    public class SearchSeedersService : ISearchSeedersService
    {

        private readonly ISearchService searchService;
        private readonly IDeletableEntityRepository<Course> coursesRepository;

        public SearchSeedersService(ISearchService searchService, IDeletableEntityRepository<Course> coursesRepository)
        {
            this.searchService = searchService;
            this.coursesRepository = coursesRepository;
        }

        public async Task SeedCoursesAsync()
        {
            var courses =
              await this.coursesRepository.AllAsNoTracking()
              .Include(c => c.Coach)
              .Include(c => c.Category)
              .Include(c => c.Companies)
              .To<CourseSearchModel>()
              .ToListAsync();

            await this.searchService.CreateManyAsync("course", courses, CancellationToken.None);
        }
    }
}
