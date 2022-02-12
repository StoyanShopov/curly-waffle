namespace SBC.Services.Data.Profile.Contracts
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Services.Data.Admin.Models;

    public interface IProfileService
    {
        Task<Result> Edit(EditProfileServiceModel model, string userId);

        Task<Result> GetAdminData(string userId);
    }
}
