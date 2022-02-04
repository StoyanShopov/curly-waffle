namespace SBC.Services.Data.Lecture.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Services.Data.Lecture.Models;

    public interface ILectureService
    {
        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<TModel> GetByIdAsync<TModel>(int id);

        Task<Result> CreateAsync(CreateLectureServiceModel courseModel);

        Task<Result> EditAsync(EditLectureServiceModel courseModel);

        Task<Result> DeleteByIdAsync(int id);
    }
}
