namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using SBC.Services.Data.Coaches;
    using SBC.Web.ViewModels.Administration.Coaches;

    public class CoachesController : AdministrationController
    {
        private readonly ICoachesService coachesService;

        public CoachesController(ICoachesService coachService)
        {
            this.coachesService = coachService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(CreateCoachInputModel coach)
        {
            var result = await this.coachesService.CreateAsync(coach);
            return this.GenericResponse(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var result = await this.coachesService.GetAllAsync<CoachDetailsViewModel>();
            return this.GenericResponse(result);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<ActionResult> Update(UpdateCoachInputModel coach)
        {
            var result = await this.coachesService.UpdateAsync(coach);
            return this.GenericResponse(result);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await this.coachesService.DeleteAsync(id);
            return this.GenericResponse(result);
        }
    }
}
