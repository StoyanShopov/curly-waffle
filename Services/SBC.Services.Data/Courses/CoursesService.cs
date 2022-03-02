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
            var courses = await this.coursesRepository
                .AllAsNoTracking()
                .Include(x => x.Companies)
                .Include(x => x.Coach)
                .ThenInclude(c => c.Company)
                .ToListAsync();

            var filteredCourses = new List<CourseCardViewModel>();

            foreach (var course in courses)
            {
                if (course.Companies.Any(x => x.CompanyId == companyId))
                {
                    filteredCourses.Add(new CourseCardViewModel
                    {
                        Id = course.Id,
                        Title = course.Title,
                        PricePerPerson = course.PricePerPerson,
                        LanguageId = course.LanguageId,
                        CategoryId = course.CategoryId,
                        CoachName = course.Coach.FirstName,
                        CompanyLogoUrl = course.Coach.CompanyId != null ? course.Coach.Company.LogoUrl : "Null",
                        IsActive = true,
                    });
                }
                else
                {
                    filteredCourses.Add(new CourseCardViewModel
                    {
                        Id = course.Id,
                        Title = course.Title,
                        PricePerPerson = course.PricePerPerson,
                        LanguageId = course.LanguageId,
                        CategoryId = course.CategoryId,
                        CoachName = course.Coach.FirstName, // check
                        CompanyLogoUrl = course.Coach.CompanyId != null ? course.Coach.Company.LogoUrl : "Null",
                        IsActive = false,
                    });
                }
            }

            return new ResultModel(filteredCourses);
        }

        public async Task<int> GetCountAsync()
            => await this.coursesRepository
                .AllAsNoTracking()
                .CountAsync();
    }
}
