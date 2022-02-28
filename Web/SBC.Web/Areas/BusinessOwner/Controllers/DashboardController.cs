namespace SBC.Web.Areas.BusinessOwner.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.BusinessOwner;

    public class DashboardController : BusinessOwnerController
    {
        private readonly IBusinessOwnerDashboardService businessOwnerDashboardService;

        public DashboardController(IBusinessOwnerDashboardService businessOwnerDashboardService)
        {
            this.businessOwnerDashboardService = businessOwnerDashboardService;
        }

        [HttpGet]
        public async Task<ActionResult> Dashboard(int companyId)
            => this.GenericResponse(await this.businessOwnerDashboardService.GetDashboard(companyId));
    }
}
