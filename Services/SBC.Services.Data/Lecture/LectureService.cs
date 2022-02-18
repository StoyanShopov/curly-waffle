namespace SBC.Services.Data.Lecture
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Lecture.Contracts;
    using SBC.Services.Data.Lecture.Models;
    using SBC.Services.Mapping;

    public class LectureService : ILectureService
    {
        private readonly IDeletableEntityRepository<Lecture> lectures;

        public LectureService(IDeletableEntityRepository<Lecture> repo)
        {
            this.lectures = repo;
        }

        public async Task<Result> CreateAsync(CreateLectureServiceModel lectureModel)
        {
            var lecture = await this.lectures
                .All()
                .FirstOrDefaultAsync(x => x.Name == lectureModel.Name);

            if (lecture != null)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, "Lecture already exist!.");
            }

            var newLecture = new Lecture()
            {
                Name = lectureModel.Name,
                Description = lectureModel.Description,
            };

            await this.lectures.AddAsync(newLecture);

            var newLectureId = newLecture.Id;

            newLecture.Courses.Add(new CourseLecture { LectureId = newLectureId, CourseId = lectureModel.CourseId });

            await this.lectures.SaveChangesAsync();

            return new ResultModel(newLecture.Id);
        }

        public async Task<Result> DeleteByIdAsync(string id)
        {
            var lecture = await this.lectures
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (lecture == null)
            {
                return new ErrorModel(HttpStatusCode.NoContent, "Lecture not found!");
            }

            this.lectures.Delete(lecture);
            await this.lectures.SaveChangesAsync();

            return true;
        }

        public async Task<Result> EditAsync(EditLectureServiceModel lectureModel)
        {
            var lecture = await this.lectures
                .All()
                .FirstOrDefaultAsync(x => x.Id == lectureModel.Id);

            if (lecture == null)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, "Lecture doesn't exist!");
            }

            lecture.Name = lectureModel.Name;
            lecture.Description = lectureModel.Description;

            await this.lectures.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TModel>> GetAllByCourseIdAsync<TModel>(int id)
        => await this.lectures
            .AllAsNoTracking()
            .Where(x => x.Courses.Any(x => x.CourseId == id))
            .To<TModel>()
            .ToListAsync();

        public async Task<TModel> GetByIdAsync<TModel>(string id)
        => await this.lectures
            .AllAsNoTracking()
            .Where(x => x.Id == id)
            .To<TModel>()
            .FirstOrDefaultAsync();
    }
}
