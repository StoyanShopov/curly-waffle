namespace SBC.Services.Data.Profile
{
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using SBC.Common;
    using SBC.Data.Models;
    using SBC.Services.Mapping;
    using SBC.Web.ViewModels.BusinessOwner;
    using SBC.Web.ViewModels.BusinessOwner.Profile;

    public class BusinessOwnerProfileService : IBusinessOwnerProfileService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public BusinessOwnerProfileService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<Result> EditAsync(EditProfileServiceModel inputModel, string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return new ErrorModel(HttpStatusCode.Unauthorized);
            }

            user.FirstName = inputModel.Fullname.Split(" ")[0];
            user.LastName = inputModel.Fullname.Split(" ")[1];
            user.ProfileSummary = inputModel.ProfileSummary;
            user.PhotoUrl = inputModel.PhotoUrl;

            var result = await this.userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return result.Succeeded;
            }

            return new ErrorModel(HttpStatusCode.BadRequest, result.Errors);
        }

        public async Task<Result> GetBusinessOwnerDataAsync(string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return new ErrorModel(HttpStatusCode.Unauthorized);
            }

            var result = AutoMapperConfig.MapperInstance.Map<BusinessOwnerViewModel>(user);

            return new ResultModel(result);
        }
    }
}
