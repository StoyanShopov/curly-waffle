namespace SBC.Web.Areas.Employee.Controlles
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Coaches;
    using SBC.Web.ViewModels.Administration.Coaches;
    using SBC.Web.ViewModels.Coaches;

    public class CoachesController : EmployeesController
    {
        private readonly ICoachesService coachesService;

        public CoachesController(ICoachesService coachesService)
        {
            this.coachesService = coachesService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await this.coachesService.GetAllAsync<CoachCardViewModel>();
            return this.GenericResponse(result);
        }
    }
}
