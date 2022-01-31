namespace SBC.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data;
    using SBC.Web.ViewModels.Administration.Dashboard;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;

        public DashboardController(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
        }
    }
}
