namespace SBC.Services.Data.User.Contracts
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Services.Data.User.Models;

    public interface IUserService
    {
        Task<Result> Register(RegisterServiceModel model);

        Task<Result> Login(LoginServiceModel model, string secret);

        Task<bool> UserExistsByEmail(string email);
    }
}
