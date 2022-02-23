namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Admin.Models;
    using SBC.Services.Data.Infrastructures;
    using SBC.Services.Data.Profile;
    using SBC.Services.Data.Profile.Contracts;

    public class ProfileController : AdministrationController
    {
        private readonly IProfileService profileService;

        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
            => this.GenericResponse(await this.profileService.GetAdminData(this.User.Id()));

        [HttpPut]
        public async Task<ActionResult> Edit(EditProfileServiceModel model)
            => this.GenericResponse(await this.profileService.Edit(model, this.User.Id()));
    }
}
