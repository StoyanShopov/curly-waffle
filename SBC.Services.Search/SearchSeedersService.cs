namespace SBC.Services.Search
{
    using Microsoft.EntityFrameworkCore;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Web.ViewModels.Search;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class SearchSeedersService : ISearchSeedersService
    {

        private readonly IDeletableEntityRepository<Course> coursesRepository;
        private readonly ISearchService searchService;

        public SearchSeedersService(IDeletableEntityRepository<Course> coursesRepository,
            ISearchService searchService)
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
              .Select(x => new CourseSearchModel
              {
                  Id = x.Id,
                  Title = x.Title,
                  PricePerPerson = x.PricePerPerson,
                  PictureUrl = x.PictureUrl,
                  CategoryId = x.CategoryId,
                  LanguageId = x.LanguageId,
                  CoachFullName = $"{x.Coach.FirstName} {x.Coach.LastName}",
                  CategoryName = x.Category.Name,
              })
              .ToListAsync();

            await this.searchService.CreateMany("course", courses, CancellationToken.None);
        }
    }
}
