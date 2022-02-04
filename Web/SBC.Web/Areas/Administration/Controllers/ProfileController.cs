namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data;
    using SBC.Services.Data.Admin.Contracts;
    using SBC.Web.ViewModels.Administration.Dashboard;

    public class ProfileController : AdministrationController
    {
        private readonly IProfileService profileService;

        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        [HttpGet]
        [Route("dashboard")]
        public async Task<ActionResult> GetDasboard() => this.GenericResponse(await this.profileService.GetDashboard());

        [HttpGet]
        [Route("clients/{page}")]
        public async Task<ActionResult> GetClients(int page) => this.GenericResponse(await this.profileService.GetCompanies(page));
    }
}
