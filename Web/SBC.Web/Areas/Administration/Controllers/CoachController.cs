namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Common;
    using SBC.Services.Data.Coach.Contracts;
    using SBC.Services.Data.Coach.Models;
    using SBC.Web.ViewModels.Administration.Coach;

    using static SBC.Common.GlobalConstants.ControllerRouteConstants;

    public class CoachController : AdministrationController
    {
        private readonly ICoachService coachService;

        public CoachController(ICoachService coachService)
        {
            this.coachService = coachService;
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterCoach coach)
        {
            return this.GenericResponse(await this.coachService.CreateAsync(coach));
        }

        [HttpGet("Coaches")]
        public async Task<ActionResult> GetAllCoachesAsync()
        {
            var result = await this.coachService.GetAllAsync<ListingCoachModel>();

            return this.GenericResponse(new ResultModel(result));
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateCoachModel coach)
        {
            return this.GenericResponse(await this.coachService.UpdateAsync(coach));
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int coachId)
        {
            return this.GenericResponse(await this.coachService.DeleteAsync(coachId));
        }
    }
}
