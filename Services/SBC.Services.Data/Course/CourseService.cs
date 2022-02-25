namespace SBC.Services.Data.Course
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
    using SBC.Web.ViewModels.Course;

    public class CourseService : ICourseService
    {
        private readonly IDeletableEntityRepository<Course> courses;
        private readonly IDeletableEntityRepository<Coach> coaches;

        public CourseService(IDeletableEntityRepository<Course> courses, IDeletableEntityRepository<Coach> coaches)
        {
            this.courses = courses;
            this.coaches = coaches;
        }

        public async Task<Result> CreateAsync(CreateCourseInputModel courseModel)
        {
            var course = await this.courses
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

            await this.courses.AddAsync(newCourse);
            await this.courses.SaveChangesAsync();

            var currentCoach = await this.coaches
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
            var course = await this.courses
                .All()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
            {
                return new ErrorModel(HttpStatusCode.NotFound, "Course not found!");
            }

            this.courses.Delete(course);
            await this.courses.SaveChangesAsync();

            return true;
        }

        public async Task<Result> EditAsync(int? id, EditCourseInputModel courseModel)
        {
            if (id == null)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, "Id is null!");
            }

            var course = await this.courses
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

            await this.courses.SaveChangesAsync();

            var currentCoach = await this.coaches
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
            => await this.courses
                .AllAsNoTracking()
                .To<TModel>()
                .ToListAsync();

        public async Task<TModel> GetByIdAsync<TModel>(int id)
            => await this.courses
                .AllAsNoTracking()
                .Where(c => c.Id == id)
                .To<TModel>()
                .FirstOrDefaultAsync();

        public async Task<int> GetCount()
            => await this.courses
                .AllAsNoTracking()
                .CountAsync();
    }
}
