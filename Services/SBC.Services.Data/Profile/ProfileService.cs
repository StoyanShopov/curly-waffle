namespace SBC.Services.Data.Profile
{
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using SBC.Common;
    using SBC.Data.Models;
    using SBC.Services.Blob;
    using SBC.Services.Data.Admin.Models;
    using SBC.Services.Data.Profile.Contracts;
    using SBC.Web.ViewModels.Administration;

    public class ProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IBlobService blobService;

        public ProfileService(
            UserManager<ApplicationUser> userManager,
            IBlobService blobService)
        {
            this.userManager = userManager;
            this.blobService = blobService;
        }

        public async Task<Result> Edit(EditProfileServiceModel model, string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ErrorModel(HttpStatusCode.Unauthorized, "User does not exist");
            }
            var names=model.Fullname.Trim().Split(" ");
            user.Email = model.Email;
            user.FirstName = names[0];
            user.LastName = names[1];
            user.ProfileSummary = model.ProfileSummary;
            user.PhotoUrl = model.PhotoUrl;

            var result = await this.userManager.UpdateAsync(user);

            return result.Succeeded
                ? result.Succeeded
                : new ErrorModel(HttpStatusCode.BadRequest, result.Errors);
        }

        public async Task<Result> GetAdminData(string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            return user != null
                ? new ResultModel(new AdminViewModel
                {
                    Fullname = user.FirstName + " " + user.LastName,
                    ProfileSummary = user.ProfileSummary,
                    PhotoUrl = user.PhotoUrl,
                    Email = user.Email,
                })
                : new ErrorModel(HttpStatusCode.Unauthorized, "User does not exist");
        }
    }
}
