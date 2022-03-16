namespace SBC.Services.Data.Courses
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Mapping;
    using SBC.Web.ViewModels.Administration.Courses;
    using SBC.Web.ViewModels.Courses;

    public class CoursesService : ICoursesService
    {
        private const int TakeDefaultValue = 3;

        private readonly IDeletableEntityRepository<Course> coursesRepository;
        private readonly IDeletableEntityRepository<Coach> coachesRepository;

        public CoursesService(
            IDeletableEntityRepository<Course> coursesRepository,
            IDeletableEntityRepository<Coach> coachesRepository)
        {
            this.coursesRepository = coursesRepository;
            this.coachesRepository = coachesRepository;
        }

        public async Task<Result> CreateAsync(CreateCourseInputModel courseModel)
        {
            var course = await this.coursesRepository
                .All()
                .FirstOrDefaultAsync(c => c.Title == courseModel.Title);

            if (course != null)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, "Course already exist!");
            }

            var newCourse = new Course()
            {
                Title = courseModel.Title,
                Description = courseModel.Description,
                PricePerPerson = courseModel.PricePerPerson,
                PictureUrl = courseModel.PictureUrl,
                VideoUrl = courseModel.VideoUrl,
                CategoryId = courseModel.CategoryId,
                LanguageId = courseModel.LanguageId,
                CoachId = courseModel.CoachId,
            };

            await this.coursesRepository.AddAsync(newCourse);
            await this.coursesRepository.SaveChangesAsync();

            var currentCoach = await this.coachesRepository
                .AllAsNoTracking()
                .Include(c => c.Company)
                .FirstOrDefaultAsync(c => c.Id == newCourse.CoachId);

            var listingModel = new CourseDetailsViewModel
            {
                Id = newCourse.Id,
                Title = newCourse.Title,
                PricePerPerson = newCourse.PricePerPerson,
                PictureUrl = newCourse.PictureUrl,
                CoachFirstName = currentCoach.FirstName,
                CoachLastName = currentCoach.LastName,
                CoachCompanyName = currentCoach.Company.Name,
            };

            return new ResultModel(listingModel);
        }

        public async Task<Result> DeleteByIdAsync(int id)
        {
            var course = await this.coursesRepository
                .All()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
            {
                return new ErrorModel(HttpStatusCode.NotFound, "Course not found!");
            }

            this.coursesRepository.Delete(course);
            await this.coursesRepository.SaveChangesAsync();

            return true;
        }

        public async Task<Result> EditAsync(int? id, EditCourseInputModel courseModel)
        {
            if (id == null)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, "Id is null!");
            }

            var course = await this.coursesRepository
                .All()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
            {
                return new ErrorModel(HttpStatusCode.NotFound, "Course doesn't exist!");
            }

            course.Title = courseModel.Title;
            course.Description = courseModel.Description;
            course.PricePerPerson = courseModel.PricePerPerson;
            course.PictureUrl = courseModel.PictureUrl;
            course.VideoUrl = courseModel.VideoUrl;
            course.CoachId = courseModel.CoachId;
            course.CategoryId = courseModel.CategoryId;
            course.LanguageId = courseModel.LanguageId;

            await this.coursesRepository.SaveChangesAsync();

            var currentCoach = await this.coachesRepository
               .AllAsNoTracking()
               .Include(c => c.Company)
               .FirstOrDefaultAsync(c => c.Id == course.CoachId);

            var listingModel = new CourseDetailsViewModel
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                PricePerPerson = course.PricePerPerson,
                PictureUrl = course.PictureUrl,
                VideoUrl = course.VideoUrl,
                CoachId = course.CoachId,
                LanguageId = course.LanguageId,
                CategoryId = course.CategoryId,
                CoachFirstName = currentCoach.FirstName,
                CoachLastName = currentCoach.LastName,
                CoachCompanyName = currentCoach.Company.Name,
            };

            return new ResultModel(listingModel);
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
            => await this.coursesRepository
                .AllAsNoTracking()
                .To<TModel>()
                .ToListAsync();

        public async Task<TModel> GetByIdAsync<TModel>(int id)
            => await this.coursesRepository
                .AllAsNoTracking()
                .Where(c => c.Id == id)
                .To<TModel>()
                .FirstOrDefaultAsync();

        public async Task<int> GetCountAsync()
            => await this.coursesRepository
                .AllAsNoTracking()
                .CountAsync();

        public async Task<Result> GetAllWithActiveAsync(int companyId, int skip = default, int take = TakeDefaultValue)
        {
            var coursesCount = await this.coursesRepository
                .AllAsNoTracking()
                .CountAsync();

            var isViewMoreAvailable = (coursesCount - skip - take) > 0;

            var portions = await this.coursesRepository
                .AllAsNoTracking()
                .OrderByDescending(u => u.CreatedOn)
                .Skip(skip)
                .Take(take)
                .Select(course => new CourseCardViewModel
                {
                    Id = course.Id,
                    Title = course.Title,
                    LanguageId = course.LanguageId,
                    CategoryId = course.CategoryId,
                    CoachFullName = $"{course.Coach.FirstName} {course.Coach.LastName}",
                    CategoryName = course.Category.Name,
                    PricePerPerson = course.PricePerPerson,
                    PictureUrl = course.PictureUrl,
                    CompanyLogoUrl = course.Coach.CompanyId != null ? course.Coach.Company.LogoUrl : "Null",
                    IsActive = course.Companies.Any(x => x.CompanyId == companyId),
                })
                .ToListAsync();

            var courses = new CoursesCardViewModel
            {
                Portions = portions,
                ViewMoreAvailable = isViewMoreAvailable,
            };

            return new ResultModel(courses);
        }
    }
}
