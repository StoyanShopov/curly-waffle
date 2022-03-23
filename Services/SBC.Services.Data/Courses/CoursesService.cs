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
    using SBC.Web.ViewModels.Employees;

    public class CoursesService : ICoursesService
    {
        private const int TakeDefaultValue = 3;

        private readonly IDeletableEntityRepository<Course> coursesRepository;
        private readonly IDeletableEntityRepository<Coach> coachesRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public CoursesService(
            IDeletableEntityRepository<Course> coursesRepository,
            IDeletableEntityRepository<Coach> coachesRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.coursesRepository = coursesRepository;
            this.coachesRepository = coachesRepository;
            this.usersRepository = usersRepository;
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

        public async Task<Result> GetAllByOwnerAsync(string employeeId)
        {
            var companyId = this.usersRepository
                .AllAsNoTracking()
                .Where(u => u.Id == employeeId)
                .Select(x => x.CompanyId)
                .FirstOrDefault();

            var user = this.usersRepository
                .AllAsNoTracking()
                .Include(x => x.Courses)
                .FirstOrDefault(x => x.Id == employeeId);

            var userCourses = user
                .Courses
                .Select(x => x.CourseId)
                .ToList();

            var activeCourses = await this.coursesRepository
                .AllAsNoTracking()
                .Where(c => c.Companies.Any(x => x.CompanyId == companyId))
                .Include(x => x.Coach)
                .ThenInclude(x => x.Company)
                .Select(x => new CourseEmployeeViewModel
                {
                    Id = x.Id,
                    CoachFullName = $"{x.Coach.FirstName} {x.Coach.LastName}",
                    PictureUrl = x.PictureUrl,
                    Title = x.Title,
                    CategoryName = x.Category.Name,
                    CompanyLogoUrl = x.Coach.Company.LogoUrl,
                    LecturesCount = x.Lectures.Count,
                    IsEnrolled = userCourses.Contains(x.Id),
                })
                .ToListAsync();

            return new ResultModel(activeCourses);
        }

        public async Task<Result> GetActiveCoursesAsync<TModel>(int companyId)
        {
            var activeCourses = await this.coursesRepository
                .AllAsNoTracking()
                .Where(c => c.Companies.Any(x => x.CompanyId == companyId))
                .Include(x => x.Coach)
                .ThenInclude(x => x.Company)
                .Select(x => new ActiveCourseViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    PricePerPerson = x.PricePerPerson,
                    PictureUrl = x.PictureUrl,
                    CategoryId = x.CategoryId,
                    LanguageId = x.LanguageId,
                    CoachFullName = $"{x.Coach.FirstName} {x.Coach.LastName}",
                    CategoryName = x.Category.Name,
                    CompanyLogoUrl = x.Coach.CompanyId != null ? x.Coach.Company.LogoUrl : "Null",
                })
                .ToListAsync();

            return new ResultModel(activeCourses);
        }

        public async Task<Result> GetByIdEmployeeAsync(int id)
        {
            var course = await this.coursesRepository
                .AllAsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            var lectures = course
                .Lectures
                .Select(x => x.Lecture)
                .ToList();

            var resourcesDuration = lectures
                .SelectMany(x => x.Resources
                .Where(x => ((int)x.FileType) == 1))
                .Sum(x => x.Size);

            var result = await this.coursesRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new EmployeeCourseDetailsViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    VideoUrl = x.VideoUrl,
                    VideosDuration = resourcesDuration,
                    LecturesCount = x.Lectures.Count(),
                    CompanyLogoUrl = x.Coach.Company.LogoUrl,
                    CoachName = $"{x.Coach.FirstName} {x.Coach.LastName}",
                    CoachPictureUrl = x.Coach.ImageUrl,
                })
                .FirstOrDefaultAsync();

            return new ResultModel(result);
        }
    }
}
