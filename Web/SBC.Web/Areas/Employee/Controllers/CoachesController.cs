namespace SBC.Web.Areas.Employee.Controlles
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Coaches;
    using SBC.Services.Data.Infrastructures;
    using SBC.Services.Data.Users;

    public class CoachesController : EmployeesController
    {
        private readonly ICoachesService coachesService;
        private readonly IUsersService usersService;

        public CoachesController(ICoachesService coachesService, IUsersService usersService)
        {
            this.coachesService = coachesService;
            this.usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            int companyId = this.usersService.GetCompanyId(this.User.Id());
            var result = await this.coachesService.GetAlLOfEmployeeAsync(companyId);
            return this.GenericResponse(result);
        }
    }
}
