namespace SBC.Services.Data.Profile
{
    using System.Net;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using SBC.Common;
    using SBC.Data.Models;
    using SBC.Services.Data.Admin.Models;
    using SBC.Services.Data.Profile;
    using SBC.Web.ViewModels.Administration;

    public class ProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfigurationProvider autoMapper;

        public ProfileService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.autoMapper = mapper.ConfigurationProvider;
        }

        public async Task<Result> EditAsync(EditProfileServiceModel inputModelUser, string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return new ErrorModel(HttpStatusCode.Unauthorized, "User does not exist");
            }

            var mapModel = this.autoMapper.CreateMapper().Map<ApplicationUser>(inputModelUser);

          // user.Email = mapModel.Email;
            user.FirstName = mapModel.FirstName;
            user.LastName = mapModel.LastName;
            user.ProfileSummary = mapModel.ProfileSummary;
            user.PhotoUrl = mapModel.PhotoUrl;

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

            var mapper = this.autoMapper.CreateMapper();
            var result = new ResultModel(mapper.Map<AdminViewModel>(user));

            return result;
        }
    }
}
