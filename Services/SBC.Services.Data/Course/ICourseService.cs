namespace SBC.Services.Data.Course
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.Course;

    public interface ICourseService
    {
        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<TModel> GetByIdAsync<TModel>(int id);

        Task<Result> CreateAsync(CreateCourseInputModel courseModel);

        Task<Result> EditAsync(int? id, EditCourseInputModel courseModel);

        Task<Result> DeleteByIdAsync(int id);

        Task<int> GetCount();
    }
}
