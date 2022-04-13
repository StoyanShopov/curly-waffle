namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Admin;

    public class DashboardController : AdministrationController
    {
        private readonly IDasboardService profileService;

        public DashboardController(IDasboardService profileService)
        {
            this.profileService = profileService;
        }

        [HttpGet]
        public async Task<ActionResult> Dasboard()
        {
            var result = await this.profileService.GetDashboardAsync();

            return this.GenericResponse(result);
        }
    }
}
