namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Coach;
    using SBC.Web.ViewModels.Administration.Coach;

    using static SBC.Common.GlobalConstants.ControllerRouteConstants;

    public class CoachesController : AdministrationController
    {
        private readonly ICoachService coachService;

        public CoachesController(ICoachService coachService)
        {
            this.coachService = coachService;
        }

        [HttpPost]
        public async Task<ActionResult> Register(CreateCoachInputModel coach)
        {
            var result = await this.coachService.CreateAsync(coach);
            return this.GenericResponse(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCoachesAsync()
        {
            var result = await this.coachService.GetAllAsync<CoachDetailsViewModel>();
            return this.GenericResponse(result);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<ActionResult> Update(UpdateCoachInputModel coach)
        {
            var result = await this.coachService.UpdateAsync(coach);
            return this.GenericResponse(result);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await this.coachService.DeleteAsync(id);
            return this.GenericResponse(result);
        }
    }
}
