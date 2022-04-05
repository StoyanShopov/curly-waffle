namespace SBC.Services.Data.Coaches
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Data.Models;
    using SBC.Web.ViewModels.Administration.Coaches;
    using SBC.Web.ViewModels.Employees.Feedback;

    using static SBC.Common.GlobalConstants.ClientConstants;

    public interface ICoachesService
    {
        Task<Result> BookCoachAsync(string employeeId, int coachId);

        Task<Result> CreateAsync(CreateCoachInputModel coach);

        Task<Result> DeleteAsync(int coachId);

        Task<Result> GetAllAsync<TModel>();

        Task<Result> GetAllOfEmployeeAsync(
            int companyId,
            string userId,
            string search);

        Task<Result> GetAllWithActiveAsync(
            int companyId,
            int skip,
            int take = TakeDefaultValue);

        Task<Result> LeftFeedbackAsync(ApplicationUser user, FeedbackInputModel feedback);

        Task<Result> UpdateAsync(UpdateCoachInputModel coach);

        Task<int> GetCountAsync();
    }
}
