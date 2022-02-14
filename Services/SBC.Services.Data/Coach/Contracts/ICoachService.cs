namespace SBC.Services.Data.Coach.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Data.Models;
    using SBC.Services.Data.Coach.Models;
    using SBC.Services.Mapping;

    public interface ICoachService
    {
        Task<Result> NewRegistrationCoach(RegisterCoach coach);

        Task<IEnumerable<TModel>> GetAll<TModel>();

        Task<Result> UpdateCoach(UpdateCoachModel coach);

        Task<Result> DeleteCoach(int coachId);
    }
}
