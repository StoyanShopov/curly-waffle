namespace SBC.Services.Data.Lectures
{
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Mapping;
    using SBC.Web.ViewModels.Administration.Lectures;

    using static SBC.Common.ErrorConstants.LecturesMessages;
    using static SBC.Common.GlobalConstants.LecturesConstants;

    public class LecturesService : ILecturesService
    {
        private readonly IDeletableEntityRepository<Lecture> lecturesRepository;
        private readonly IDeletableEntityRepository<CourseLecture> courseLecturesRepository;

        public LecturesService(
            IDeletableEntityRepository<Lecture> lecturesRepository,
            IDeletableEntityRepository<CourseLecture> courseLecturesRepository)
        {
            this.lecturesRepository = lecturesRepository;
            this.courseLecturesRepository = courseLecturesRepository;
        }

        public async Task<Result> CreateAsync(CreateLectureInputModel lectureModel)
        {
            var lecture = await this.lecturesRepository
                .All()
                .FirstOrDefaultAsync(x => x.Name == lectureModel.Name);

            if (lecture != null)
            {
                return new ErrorModel(
                    HttpStatusCode.BadRequest,
                    LectureAlreadyExist);
            }

            var newLecture = new Lecture()
            {
                Name = lectureModel.Name,
                Description = lectureModel.Description,
            };

            await this.lecturesRepository.AddAsync(newLecture);

            var newLectureId = newLecture.Id;

            newLecture.Courses.Add(new CourseLecture { LectureId = newLectureId, CourseId = lectureModel.CourseId });

            await this.lecturesRepository.SaveChangesAsync();

            lectureModel.Id = newLecture.Id;

            return new ResultModel(lectureModel);
        }

        public async Task<Result> DeleteAsync(string id)
        {
            var lecture = await this.lecturesRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            var courseLecture = await this.courseLecturesRepository
                .All()
                .FirstOrDefaultAsync(x => x.LectureId == id);

            if (lecture == null)
            {
                return new ErrorModel(
                    HttpStatusCode.NoContent,
                    LectureNotFound);
            }

            this.lecturesRepository.Delete(lecture);
            this.courseLecturesRepository.Delete(courseLecture);

            await this.courseLecturesRepository.SaveChangesAsync();
            await this.lecturesRepository.SaveChangesAsync();

            return true;
        }

        public async Task<Result> UpdateAsync(string id, EditLectureInputModel lectureModel)
        {
            var lecture = await this.lecturesRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (lecture == null)
            {
                return new ErrorModel(
                    HttpStatusCode.BadRequest,
                    LectureDoesNotExist);
            }

            lecture.Name = lectureModel.Name;
            lecture.Description = lectureModel.Description;

            await this.lecturesRepository.SaveChangesAsync();
            lectureModel.Id = lecture.Id;

            return new ResultModel(lectureModel);
        }

        public async Task<Result> GetAllByCourseIdAsync<TModel>(
            int skip,
            int id,
            int take = LecturesToTake)
        => new ResultModel(await this.lecturesRepository
            .AllAsNoTracking()
            .Where(x => x.Courses.Any(x => x.CourseId == id))
            .OrderByDescending(x => x.CreatedOn)
            .To<TModel>()
            .Skip(skip)
            .Take(take)
            .ToListAsync());

        public async Task<Result> GetByIdAsync<TModel>(string id)
        => new ResultModel(await this.lecturesRepository
            .AllAsNoTracking()
            .Where(x => x.Id == id)
            .To<TModel>()
            .FirstOrDefaultAsync());
    }
}
