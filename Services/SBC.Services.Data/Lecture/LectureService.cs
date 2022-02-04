namespace SBC.Services.Data.Lecture
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Lecture.Contracts;
    using SBC.Services.Data.Lecture.Models;

    public class LectureService : ILectureService
    {
        private readonly IDeletableEntityRepository<Lecture> lectures;

        public LectureService(IDeletableEntityRepository<Lecture> repo)
        {
            this.lectures = repo;
        }

        public Task<Result> CreateAsync(CreateLectureServiceModel courseModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result> DeleteByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result> EditAsync(EditLectureServiceModel courseModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TModel>> GetAllAsync<TModel>()
        {
            throw new System.NotImplementedException();
        }

        public Task<TModel> GetByIdAsync<TModel>(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
