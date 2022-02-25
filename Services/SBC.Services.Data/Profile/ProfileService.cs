namespace SBC.Services.Data.Profile
{
    using System.Net;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using SBC.Common;
    using SBC.Data.Models;
    using SBC.Services.Data.Profile;
    using SBC.Services.Mapping;
    using SBC.Web.ViewModels.Administration;
    using SBC.Web.ViewModels.Administration.Profile;

    public class ProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ProfileService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<Result> EditAsync(EditProfileServiceModel inputModelUser, string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return new ErrorModel(HttpStatusCode.Unauthorized, "User does not exist");
            }

            // user.Email = mapModel.Email;
            user.FirstName = inputModelUser.Fullname.Split(" ")[0];
            user.LastName = inputModelUser.Fullname.Split(" ")[1];
            user.ProfileSummary = inputModelUser.ProfileSummary;
            user.PhotoUrl = inputModelUser.PhotoUrl;

            var result = await this.userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return result.Succeeded;
            }

            return new ErrorModel(HttpStatusCode.BadRequest, result.Errors);
        }

        public async Task<Result> GetAdminDataAsync(string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);

            if (user == null)
            {
                // TODO => error constant
                return new ErrorModel(HttpStatusCode.Unauthorized, "User does not exist");
            }

            var result = AutoMapperConfig.MapperInstance.Map<AdminViewModel>(user);

            return new ResultModel(result);
        }
    }
}
