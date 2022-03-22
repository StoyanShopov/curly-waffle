namespace SBC.Services.Data.Companies
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.Administration.Companies;
    using SBC.Web.ViewModels.BusinessOwner.Employees;

    public interface ICompaniesService
    {
        Task<Result> GetEmployeesAsync(string managerId, int skip, int take = 3);

        Task<Result> AddEmployeeAsync(CreateEmployeeInputModel model, int companyId, string userId);

        Task<Result> RemoveEmployeeAsync(string employeeId);

        Task<Result> GetActiveCoursesAsync(int companyId);

        Task<Result> SetCourseToActiveAsync(int courseId, int companyId);

        Task<Result> RemoveCourseAsync(int courseId, int companyId);

        Task<Result> GetActiveCoachesAsync(int companyId);

        Task<Result> SetCoachToActiveAsync(int coachId, int companyId);

        Task<Result> AddAsync(CreateCompanyInputModel model);

        Task<Result> GetAllEmployeesAsync(int companyId);

        Task<Result> GetEmailByIdAsync(int id);

        Task<Result> RemoveCoachAsync(int coachId, int companyId);

        Task<Result> GetAllAsync<TModel>();

        Task<int> GetCountAsync();

        Task<bool> ExistsByEmailAsync(string email);

        Task<bool> ExistsOwnerAsync(string name);

        Task<bool> ExistsByNameAsync(string name);

        Task<int> GetIdByNameAsync(string name);
    }
}
