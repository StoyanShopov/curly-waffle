namespace SBC.Web.Areas.BusinessOwner.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Coaches;

    public class CoachesController : BusinessOwnerController
    {
        private readonly ICoachesService coachesService;

        public CoachesController(ICoachesService coachesService)
        {
            this.coachesService = coachesService;
        }

        [HttpGet]
        [Route("/coachCatalog")]
        public async Task<ActionResult> GetCoachesCatalog(int companyId)
            => this.GenericResponse(await this.coachesService.GetAllWithActive(companyId));
    }
}
