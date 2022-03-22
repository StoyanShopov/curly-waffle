namespace SBC.Services.Data.Coaches
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.Administration.Coaches;
    using SBC.Web.ViewModels.Feedback;

    public interface ICoachesService
    {
        Task<Result> LeftFeedback(string employeeId, FeedbackInputModel feedback);

        Task<Result> BookCoachAsync(string employeeId, string coachId);

        Task<Result> GetAlLOfEmployeeAsync(int userId);

        Task<Result> CreateAsync(CreateCoachInputModel coach);

        Task<Result> GetAllAsync<TModel>();

        Task<Result> UpdateAsync(UpdateCoachInputModel coach);

        Task<Result> DeleteAsync(int coachId);

        Task<Result> GetAllWithActiveAsync(int companyId, int skip, int take = 3);

        Task<int> GetCountAsync();
    }
}
