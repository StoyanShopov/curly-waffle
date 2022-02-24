namespace SBC.Services.Data.Profile
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Services.Data.Admin.Models;

    public interface IProfileService
    {
        Task<Result> EditAsync(EditProfileServiceModel model, string userId);

        Task<Result> GetAdminDataAsync(string userId);
    }
}
