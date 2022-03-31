namespace SBC.Services.Data.Coaches
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Data.Models;
    using SBC.Web.ViewModels.Administration.Coaches;
    using SBC.Web.ViewModels.Feedback;

    public interface ICoachesService
    {
        Task<Result> BookCoachAsync(string employeeId, int coachId);

        Task<Result> CreateAsync(CreateCoachInputModel coach);

        Task<Result> GetAlLOfEmployeeAsync(int companyId, string userId, string search);

        Task<Result> GetAllAsync<TModel>();

        Task<Result> UpdateAsync(UpdateCoachInputModel coach);

        Task<Result> DeleteAsync(int coachId);

        Task<Result> GetAllWithActiveAsync(int companyId, int skip, int take = 3);

        Task<Result> LeftFeedback(ApplicationUser user, FeedbackInputModel feedback);

        Task<int> GetCountAsync();
    }
}
