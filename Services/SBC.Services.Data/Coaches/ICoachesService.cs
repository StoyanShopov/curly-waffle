namespace SBC.Services.Data.Coaches
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.Administration.Coaches;

    public interface ICoachesService
    {
        Task<Result> CreateAsync(CreateCoachInputModel coach);

        Task<Result> GetAllAsync<TModel>();

        Task<Result> UpdateAsync(UpdateCoachInputModel coach);

        Task<Result> DeleteAsync(int coachId);

        Task<Result> GetAllWithActive(int companyId, int skip, int take = 3);

        Task<int> GetCountAsync();
    }
}
