namespace SBC.Services.Data.Courses
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Course.Contracts;
    using SBC.Services.Data.Course.Models;
    using SBC.Services.Mapping;

    public class CourseService : ICourseService
    {
        private readonly IDeletableEntityRepository<Course> courses;

        public CourseService(IDeletableEntityRepository<Course> courses)
        {
            this.courses = courses;
        }

        public async Task<Result> CreateAsync(CreateCourseServiceModel courseModel)
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
                VideoUrl = courseModel.VideoUrl,
                CategoryId = courseModel.CategoryId,
                LanguageId = courseModel.LanguageId,
                CoachId = courseModel.CoachId,
            };

            await this.courses.AddAsync(newCourse);
            await this.courses.SaveChangesAsync();

            return true;
        }

        public Task<Result> DeleteByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result> EditAsync(EditCourseServiceModel courseModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Result> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
