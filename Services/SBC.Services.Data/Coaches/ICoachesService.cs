namespace SBC.Services.Data.Coach
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Data.Models;
    using SBC.Services.Mapping;
    using SBC.Web.ViewModels.Administration.Coach;

    public interface ICoachesService
    {
        Task<Result> CreateAsync(CreateCoachInputModel coach);

        Task<Result> GetAllAsync<TModel>();

        Task<Result> UpdateAsync(UpdateCoachInputModel coach);

        Task<Result> DeleteAsync(int coachId);
    }
}
