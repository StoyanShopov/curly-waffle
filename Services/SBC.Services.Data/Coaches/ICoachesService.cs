namespace SBC.Services.Data.Coaches
{
    using System.Threading.Tasks;

    using SBC.Common;

    public interface ICoachesService
    {
        Task<Result> GetAllWithActive(int companyId);
    }
}
