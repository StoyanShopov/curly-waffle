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

        private readonly IDeletableEntityRepository<Course> coursesRepository;
        private readonly ISearchService searchService;

        public SearchSeedersService(IDeletableEntityRepository<Course> coursesRepository,ISearchService searchService)
        {
            this.coursesRepository = coursesRepository;
            this.searchService = searchService;
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
