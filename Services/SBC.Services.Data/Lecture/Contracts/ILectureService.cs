namespace SBC.Services.Data.Lecture.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Services.Data.Lecture.Models;

    public interface ILectureService
    {
        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<TModel> GetByIdAsync<TModel>(string id);

        Task<Result> CreateAsync(CreateLectureServiceModel lectureMmodel);

        Task<Result> EditAsync(EditLectureServiceModel lectureModel);

        Task<Result> DeleteByIdAsync(string id);
    }
}
