namespace SBC.Services.Data.Courses
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.Administration.Courses;

    using static SBC.Common.GlobalConstants.ClientConstants;

    public interface ICoursesService
    {
        Task<Result> CreateAsync(CreateCourseInputModel courseModel);

        Task<Result> DeleteByIdAsync(int id);

        Task<Result> EnrollCourseAsync(string userId, int courseId);

        Task<Result> GetAllAsync<TModel>();

        Task<Result> GetAllByOwnerAsync(string employeeId);

        Task<Result> GetAllWithActiveAsync(int companyId, int skip, int take = TakeDefaultValue);

        Task<Result> GetByIdAsync<TModel>(int id);

        Task<Result> GetByIdEmployeeAsync(int id);

        Task<Result> UpdateAsync(int? id, EditCourseInputModel courseModel);

        Task<int> GetCountAsync();
    }
}
