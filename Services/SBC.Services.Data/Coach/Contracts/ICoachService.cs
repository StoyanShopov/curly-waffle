namespace SBC.Services.Data.Coach.Contracts
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Services.Data.Coach.Models;

    public interface ICoachService
    {
        Task<Result> NewRegistrationCoach(RegisterCoach coach);

        Task<Result> Get(LoginCoach coach);
    }
}
