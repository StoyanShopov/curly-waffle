namespace SBC.Services.Data.Users
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Data.Models;
    using SBC.Web.ViewModels.User;

    public interface IUsersService
    {
        Task<ApplicationUser> GetUserAsync(string userId);

        Task<Result> RegisterAsync(RegisterInputModel model);

        Task<Result> LoginAsync(LoginInputModel model, string secret);

        Task<Result> UpdateAsync(EditProfileInputModel model, string userId);

        Task<Result> GetUserDataAsync<TModel>(string userId);

        Task<TModel> GetByEmailAsync<TModel>(string email);

        Task<bool> ExistsByFullNameByEmailAsync(string fullName, string email);

        Task<bool> ExistsByEmailAsync(string email);

        int GetCompanyId(string userId);
    }
}