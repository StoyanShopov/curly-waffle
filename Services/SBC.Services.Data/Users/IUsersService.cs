namespace SBC.Services.Data.Users
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.Administration.Profile;
    using SBC.Web.ViewModels.User;

    public interface IUsersService
    {
        Task<Result> RegisterAsync(RegisterInputModel model);

        Task<Result> LoginAsync(LoginInputModel model, string secret);

        Task<Result> EditAsync(EditProfileInputModel model, string userId);

        Task<Result> GetUserDataAsync<TModel>(string userId);

        Task<TModel> GetByEmailAsync<TModel>(string email);

        Task<bool> ExistsByFullNameByEmailAsync(string fullName, string email);

        Task<bool> ExistsByEmailAsync(string email);

        int GetCompanyId(string userId);
    }
}
