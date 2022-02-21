namespace SBC.Services.Data.Lecture.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Services.Data.Lecture.Models;

    public interface ILectureService
    {
        Task<IEnumerable<TModel>> GetAllByCourseIdAsync<TModel>(int id);

        Task<TModel> GetByIdAsync<TModel>(string id);

        Task<Result> CreateAsync(CreateLectureServiceModel lectureMmodel);

        Task<Result> EditAsync(string id, EditLectureServiceModel lectureModel);

        Task<Result> DeleteByIdAsync(string id);
    }
}
