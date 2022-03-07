namespace SBC.Services.Data.Courses
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Web.ViewModels.Courses;

    public class CoursesService : ICoursesService
    {
        private readonly IDeletableEntityRepository<Course> coursesRepository;

        public CoursesService(IDeletableEntityRepository<Course> coursesRepository)
        {
            this.coursesRepository = coursesRepository;
        }

        public async Task<Result> GetAllWithActive(int companyId)
        {
            var filteredCourses = await this.coursesRepository
               .AllAsNoTracking()
               .Select(course => new CourseCardViewModel
               {
                   Id = course.Id,
                   Title = course.Title,
                   LanguageId = course.LanguageId,
                   CategoryId = course.CategoryId,
                   CoachFullName = $"{course.Coach.FirstName} {course.Coach.LastName}",
                   CategoryName = course.Category.Name,
                   PricePerPerson = course.PricePerPerson,
                   CompanyLogoUrl = course.Coach.CompanyId != null ? course.Coach.Company.LogoUrl : "Null",
                   IsActive = course.Companies.Any(x => x.CompanyId == companyId),
               })
               .ToListAsync();

            return new ResultModel(filteredCourses);
        }

        public async Task<int> GetCountAsync()
            => await this.coursesRepository
                .AllAsNoTracking()
                .CountAsync();
    }
}
