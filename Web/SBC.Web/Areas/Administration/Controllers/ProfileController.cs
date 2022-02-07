namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Admin.Models;
    using SBC.Services.Data.Infrastructures;

    public class ProfileController : AdministrationController
    {
        private readonly IDeletableEntityRepository<ApplicationUser> applicationUser;
        private readonly UserManager<ApplicationUser> userManager;

        public ProfileController(
            IDeletableEntityRepository<ApplicationUser> applicationUser,
            UserManager<ApplicationUser> userManager)
        {
            this.applicationUser = applicationUser;
            this.userManager = userManager;
        }

        [HttpPut]
        [Route(nameof(Edit))]

        public async Task<ActionResult> Edit(EditProfileServiceModel model)
        {
            var userId = this.User.Id();

            var user = await this.userManager.FindByIdAsync(userId);

            user.Email = model.Email;
            user.FirstName = model.Fullname;
            user.ProfileSummary = model.ProfileSummary;
            // user.PhotoUrl = model.PhotoUrl;

            var result = await this.userManager.UpdateAsync(user);

            return this.GenericResponse(new ResultModel(
            new
            {
                Result = result,
            }));
        }
    }
}
