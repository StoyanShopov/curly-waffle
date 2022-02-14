namespace SBC.Services.Data.Course.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Services.Data.Course.Models;

    public interface ICourseService
    {
        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<TModel> GetByIdAsync<TModel>(int id);

        Task<Result> CreateAsync(CreateCourseServiceModel courseModel);

        Task<Result> EditAsync(EditCourseServiceModel courseModel);

        Task<Result> DeleteByIdAsync(int id);

        Task<int> GetCount();
    }
}
