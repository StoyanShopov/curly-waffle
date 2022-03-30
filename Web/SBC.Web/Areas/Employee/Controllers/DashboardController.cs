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
        public async Task<ActionResult> GetAsync()
        {
            var userId = this.User.Id();

            var result = await this.employeesDashboardService.GetAsync(userId);

            return this.GenericResponse(result);
        }
    }
}
