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
    using SBC.Services.Mapping;
    using SBC.Web.ViewModels.Administration.Lecture;

    public class LectureService : ILectureService
    {
        private const int LecturesToTake = 6;
        private readonly IDeletableEntityRepository<Lecture> lectures;
        private readonly IDeletableEntityRepository<CourseLecture> courseLectures;

        public LectureService(IDeletableEntityRepository<Lecture> repo, IDeletableEntityRepository<CourseLecture> courseLectures)
        {
            this.lectures = repo;
            this.courseLectures = courseLectures;
        }

        public async Task<Result> CreateAsync(CreateLectureInputModel lectureModel)
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

            lectureModel.Id = newLecture.Id;

            return new ResultModel(lectureModel);
        }

        public async Task<Result> DeleteByIdAsync(string id)
        {
            var lecture = await this.lectures
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            var courseLecture = await this.courseLectures
                .All()
                .FirstOrDefaultAsync(x => x.LectureId == id);

            if (lecture == null)
            {
                return new ErrorModel(HttpStatusCode.NoContent, "Lecture not found!");
            }

            this.lectures.Delete(lecture);
            this.courseLectures.Delete(courseLecture);

            await this.courseLectures.SaveChangesAsync();
            await this.lectures.SaveChangesAsync();

            return true;
        }

        public async Task<Result> EditAsync(string id, EditLectureInputModel lectureModel)
        {
            var lecture = await this.lectures
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (lecture == null)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, "Lecture doesn't exist!");
            }

            lecture.Name = lectureModel.Name;
            lecture.Description = lectureModel.Description;

            await this.lectures.SaveChangesAsync();
            lectureModel.Id = lecture.Id;
            return new ResultModel(lectureModel);
        }

        public async Task<IEnumerable<TModel>> GetAllByCourseIdAsync<TModel>(int skip, int id, int take = LecturesToTake)
        => await this.lectures
            .AllAsNoTracking()
            .Where(x => x.Courses.Any(x => x.CourseId == id))
            .OrderByDescending(x => x.CreatedOn)
            .To<TModel>()
            .Skip(skip)
            .Take(take)
            .ToListAsync();

        public async Task<TModel> GetByIdAsync<TModel>(string id)
        => await this.lectures
            .AllAsNoTracking()
            .Where(x => x.Id == id)
            .To<TModel>()
            .FirstOrDefaultAsync();
    }
}
