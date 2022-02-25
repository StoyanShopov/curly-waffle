namespace SBC.Services.Data.Profile
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.Administration.Profile;

    public interface IProfileService
    {
        Task<Result> EditAsync(EditProfileServiceModel model, string userId);

        Task<Result> GetAdminDataAsync(string userId);
    }
}
