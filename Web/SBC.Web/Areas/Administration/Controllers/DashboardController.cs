namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data;
    using SBC.Services.Data.Admin.Contracts;
    using SBC.Web.ViewModels.Administration.Dashboard;

    public class DashboardController : AdministrationController
    {
        private readonly IDasboardService profileService;

        public DashboardController(IDasboardService profileService)
        {
            this.profileService = profileService;
        }

        [HttpGet]
        [Route("dashboard")]
        public async Task<ActionResult> GetDasboard() => this.GenericResponse(await this.profileService.GetDashboard());
    }
}
