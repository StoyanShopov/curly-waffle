namespace SBC.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data;
    using SBC.Web.ViewModels.Settings;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Common;

    public class SettingsController : ApiController
    {
        private readonly ISettingsService settingsService;

        private readonly IDeletableEntityRepository<Setting> repository;

        public SettingsController(ISettingsService settingsService, IDeletableEntityRepository<Setting> repository)
        {
            this.settingsService = settingsService;
            this.repository = repository;
        }

        //public IActionResult Index()
        //{
        //    var settings = this.settingsService.GetAll<SettingViewModel>();
        //    var model = new SettingsListViewModel { Settings = settings };
        //    return this.View(model);
        //}

        public async Task<IActionResult> InsertSetting()
        {
            var random = new Random();
            var setting = new Setting { Name = $"Name_{random.Next()}", Value = $"Value_{random.Next()}" };

            await this.repository.AddAsync(setting);
            await this.repository.SaveChangesAsync();

            return await this.GenericResponse((Result)true);
        }
    }
}
