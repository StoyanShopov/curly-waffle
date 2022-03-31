namespace SBC.Services.Data.Courses
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.Administration.Courses;

    public interface ICoursesService
    {
        Task<Result> CreateAsync(CreateCourseInputModel courseModel);

        Task<Result> DeleteByIdAsync(int id);

        Task<Result> EditAsync(int? id, EditCourseInputModel courseModel);

        Task<Result> EnrollCourseAsync(string userId, int courseId);

        Task<Result> GetAllWithActiveAsync(int companyId, int skip, int take = 3);

        Task<Result> GetAllByOwnerAsync(string employeeId);

        Task<Result> GetByIdEmployeeAsync(int id);

        Task<TModel> GetByIdAsync<TModel>(int id);

        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<int> GetCountAsync();
    }
}
