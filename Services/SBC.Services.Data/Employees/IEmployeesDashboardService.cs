using SBC.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBC.Services.Data.Employees
{
    public interface IEmployeesDashboardService
    {
        Task<Result> GetAsync(string userId);
    }
}
