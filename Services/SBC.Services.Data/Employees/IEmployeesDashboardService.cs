namespace SBC.Services.Data.Employees
{
    using System.Threading.Tasks;

    using SBC.Common;

    public interface IEmployeesDashboardService
    {
        Task<Result> GetAsync(string userId);
    }
}
