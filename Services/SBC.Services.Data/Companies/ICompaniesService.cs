namespace SBC.Services.Data.Companies
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.Administration.Companies;
    using SBC.Web.ViewModels.BusinessOwner.Employees;

    using static SBC.Common.GlobalConstants.ClientConstants;

    public interface ICompaniesService
    {
        Task<Result> AddAsync(CreateCompanyInputModel model);

        Task<Result> AddEmployeeAsync(
           CreateEmployeeInputModel model,
           int companyId,
           string userId);

        Task<Result> GetActiveCoachesAsync(int companyId);

        Task<Result> GetActiveCoursesAsync(int companyId);

        Task<Result> GetAllAsync<TModel>();

        Task<Result> GetEmailByIdAsync(int id);

        Task<Result> GetEmployeesAsync(
            string managerId,
            int skip,
            int take = TakeDefaultValue);

        Task<Result> RemoveEmployeeAsync(string employeeId);

        Task<Result> RemoveCoachAsync(int coachId, int companyId);

        Task<Result> RemoveCourseAsync(int courseId, int companyId);

        Task<Result> SetCoachToActiveAsync(int coachId, int companyId);

        Task<Result> SetCourseToActiveAsync(int courseId, int companyId);

        Task<IEnumerable<string>> GetAllEmployeesAsync(string companyName);

        Task<int> GetCountAsync();

        Task<int> GetIdByNameAsync(string name);

        Task<bool> ExistsByEmailAsync(string email);

        Task<bool> ExistsByNameAsync(string name);

        Task<bool> ExistsOwnerAsync(string name);
    }
}
