namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Coach.Contracts;
    using SBC.Services.Data.Coach.Models;

    using static SBC.Common.GlobalConstants.ControllerRouteConstants;

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

        [HttpGet(GetAllRoute)]
        public async Task<ActionResult<List<ListingCoachModel>>> GetAllCoachesAsync()
        {
            return await this.coachService.GetAll();
        }

        [Route("update")]
        [HttpPut]
        public async Task<ActionResult> Update(UpdateCoachModel coach)
        {
            return this.GenericResponse(await this.coachService.UpdateCoach(coach));
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int coachId)
        {
            return this.GenericResponse(await this.coachService.DeleteCoach(coachId));
        }
    }
}
