namespace SBC.Services.Data.Profile
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.BusinessOwner.Profile;

    public interface IBusinessOwnerProfileService
    {
        Task<Result> EditAsync(EditProfileServiceModel inputModel, string userId);

        Task<Result> GetBusinessOwnerDataAsync(string userId);
    }
}
