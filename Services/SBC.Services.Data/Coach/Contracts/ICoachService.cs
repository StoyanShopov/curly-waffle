namespace SBC.Services.Data.Coach.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Services.Data.Coach.Models;

    public interface ICoachService
    {
        Task<Result> NewRegistrationCoach(RegisterCoach coach);

        Task<List<ListingCoachModel>> GetAll();

        Task<Result> UpdateCoach(UpdateCoachModel coach);

        Task<Result> DeleteCoach(int coachId);
    }
}
