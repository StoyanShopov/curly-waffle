namespace SBC.Services.Data.User.Contracts
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Data.Models;
    using SBC.Services.Data.User.Models;

    public interface IUserService
    {
        Task<Result> Register(RegisterServiceModel model);

        Task<Result> Login(LoginServiceModel model, string secret);

        Task<ApplicationUser> GetByEmailIncludedRolesAndCompanyAsync(string email);

        Task<ApplicationUser> GetByEmailAsync(string email);

        Task<bool> ExistsByFullNameByEmailAsync(string fullName, string email);

        Task<bool> ExistsByEmailAsync(string email);
    }
}
