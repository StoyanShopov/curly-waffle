namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Coach.Contracts;
    using SBC.Services.Data.Coach.Models;

    [ApiController]
    [Route("[controller]")]
    public class CoachesController : AdministrationController
    {
        private readonly ICoachService coachService;

        public CoachesController(ICoachService coachService)
        {
            this.coachService = coachService;
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult> Register(RegisterCoach coach)
        {
            return this.GenericResponse(await this.coachService.NewRegistrationCoach(coach));
        }
    }
}
