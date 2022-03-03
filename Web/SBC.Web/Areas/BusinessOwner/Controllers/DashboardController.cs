namespace SBC.Web.Areas.BusinessOwner.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.BusinessOwner;
    using SBC.Services.Data.Infrastructures;

    public class DashboardController : BusinessOwnerController
    {
        private readonly IBusinessOwnerDashboardService businessOwnerDashboardService;

        public DashboardController(IBusinessOwnerDashboardService businessOwnerDashboardService)
        {
            this.businessOwnerDashboardService = businessOwnerDashboardService;
        }

        [HttpGet]
        public async Task<ActionResult> Dashboard()
            => this.GenericResponse(await this.businessOwnerDashboardService.GetDashboard(this.User.Id()));
    }
}
