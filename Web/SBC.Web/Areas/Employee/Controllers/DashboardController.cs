namespace SBC.Web.Areas.Employee.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Employees;
    using SBC.Services.Data.Infrastructures;

    public class DashboardController : EmployeesBaseController
    {
        private readonly IEmployeesDashboardService employeesDashboardService;

        public DashboardController(IEmployeesDashboardService employeesDashboardService)
        {
            this.employeesDashboardService = employeesDashboardService;
        }

        [HttpGet]
        public async Task<ActionResult> GetSessionsAsync()
        {
            var result = await this.employeesDashboardService.GetUserCoacheSessionsAsync(this.User.Id());

            return this.GenericResponse(result);
        }
    }
}
