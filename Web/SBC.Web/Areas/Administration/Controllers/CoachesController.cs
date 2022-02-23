namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Common;
    using SBC.Services.Data.Coach;
    using SBC.Services.Data.Coach.Models;
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
        public async Task<ActionResult> Register(RegisterCoach coach)
        {
            var result = await this.coachService.CreateAsync(coach);
            return this.GenericResponse(result);
        }

        [HttpGet(nameof(GetAllCoachesAsync))]
        public async Task<ActionResult> GetAllCoachesAsync()
        {
            var result = await this.coachService.GetAllAsync<ListingCoachModel>();
            return this.GenericResponse(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateCoachModel coach)
        {
            var result = await this.coachService.UpdateAsync(coach);
            return this.GenericResponse(result);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int coachId)
        {
            var result = await this.coachService.DeleteAsync(coachId);
            return this.GenericResponse(result);
        }
    }
}
