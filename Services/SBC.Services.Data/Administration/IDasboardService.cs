namespace SBC.Services.Data.Admin
{
    using System.Threading.Tasks;

    using SBC.Common;

    public interface IDasboardService
    {
        Task<Result> GetDashboardAsync();
    }
}
