namespace SBC.Services.Data.Coach
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Data.Models;
    using SBC.Services.Data.Coach.Models;
    using SBC.Services.Mapping;

    public interface ICoachService
    {
        Task<Result> CreateAsync(RegisterCoach coach);

        Task<Result> GetAllAsync<TModel>();

        Task<Result> UpdateAsync(UpdateCoachModel coach);

        Task<Result> DeleteAsync(int coachId);
    }
}
