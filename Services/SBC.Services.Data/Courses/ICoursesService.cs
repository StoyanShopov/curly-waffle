namespace SBC.Services.Data.Courses
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.Administration.Courses;

    public interface ICoursesService
    {
        Task<Result> GetAllWithActiveAsync(int companyId, int skip, int take = 3);

        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<TModel> GetByIdAsync<TModel>(int id);

        Task<Result> CreateAsync(CreateCourseInputModel courseModel);

        Task<Result> EditAsync(int? id, EditCourseInputModel courseModel);

        Task<Result> DeleteByIdAsync(int id);

        Task<int> GetCountAsync();
    }
}
