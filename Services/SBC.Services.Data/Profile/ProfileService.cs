namespace SBC.Services.Data.Profile
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using SBC.Common;
    using SBC.Data.Models;
    using SBC.Services.Data.Admin.Models;
    using SBC.Services.Data.Profile.Contracts;

    public class ProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ProfileService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<Result> Edit(EditProfileServiceModel model, string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);

            user.Email = model.Email;
            user.FirstName = model.Fullname;
            user.ProfileSummary = model.ProfileSummary;
            //user.PhotoUrl = model.PhotoUrl;

            var result = await this.userManager.UpdateAsync(user);

            return new ResultModel(
                new
                {
                    Result = result,
                });
        }
    }
}
