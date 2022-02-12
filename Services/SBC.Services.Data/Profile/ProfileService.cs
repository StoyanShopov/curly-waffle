namespace SBC.Services.Data.Profile
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using SBC.Common;
    using SBC.Data.Models;
    using SBC.Services.Blob;
    using SBC.Services.Data.Admin.Models;
    using SBC.Services.Data.Profile.Contracts;

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

            user.Email = model.Email;
            user.FirstName = model.Fullname;
            user.ProfileSummary = model.ProfileSummary;
            user.PhotoUrl = await this.blobService.UploadFileBlobAsync(model.PhotoUrl);

            var result = await this.userManager.UpdateAsync(user);

            return new ResultModel(
                new
                {
                    Result = result,
                });
        }
    }
}
