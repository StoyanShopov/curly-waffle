namespace SBC.Services.Data.BusinessOwner
{
    using System.Threading.Tasks;

    using SBC.Common;

    public interface IBusinessOwnerDashboardService
    {
        Task<Result> GetDashboard(int companyId);
    }
}
