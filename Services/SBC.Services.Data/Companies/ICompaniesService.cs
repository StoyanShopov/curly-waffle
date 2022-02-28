namespace SBC.Services.Data.Companies
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.BusinessOwner.Employees;

    public interface ICompaniesService
    {
        Task<bool> ExistsByNameAsync(string name);

        Task<int> NoTrackGetCompanyByNameAsync(string name);

        Task<Result> GetEmployees(string managerId, int skip, int take = 3);

        Task<Result> AddEmployee(CreateEmployeeInputModel model);

        Task<Result> RemoveEmployee(string employeeId);

        Task<Result> GetActiveCourses(int companyId);

        Task<Result> SetCourseToActive(int courseId, int companyId);

        Task<Result> RemoveCourse(int courseId, int companyId);

        Task<Result> GetActiveCoaches(int companyId);

        Task<Result> SetCoachToActive(int coachId, int companyId);

        Task<Result> RemoveCoach(int coachId, int companyId);
    }
}
