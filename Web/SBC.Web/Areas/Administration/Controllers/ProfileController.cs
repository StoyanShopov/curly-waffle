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

    public class ProfileController : AdministrationController
    {
        private readonly IDeletableEntityRepository<ApplicationUser> applicationUser;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ProfileService profileService;

        public ProfileController(
            IDeletableEntityRepository<ApplicationUser> applicationUser,
            UserManager<ApplicationUser> userManager,
            ProfileService profileService)
        {
            this.applicationUser = applicationUser;
            this.userManager = userManager;
            this.profileService = profileService;
        }

        [HttpPut]
        [Route(nameof(Edit))]
        public async Task<ActionResult> Edit(EditProfileServiceModel model)
            => this.GenericResponse(await this.profileService.Edit(model, this.User.Id()));
    }
}
