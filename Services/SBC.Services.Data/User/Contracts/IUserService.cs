namespace SBC.Services.Data.User.Contracts
{
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<bool> UserExistsByEmail(string email);
    }
}
