namespace SBC.Services.Data.User
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.User;

    public interface IUsersService
    {
        Task<Result> RegisterAsync(RegisterInputModel model);

        Task<Result> LoginAsync(LoginInputModel model, string secret);

        Task<TModel> GetByEmailAsync<TModel>(string email);

        Task<bool> ExistsByFullNameByEmailAsync(string fullName, string email);

        Task<bool> ExistsByEmailAsync(string email);
    }
}
