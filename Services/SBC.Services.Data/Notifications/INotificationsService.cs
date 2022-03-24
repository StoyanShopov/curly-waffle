namespace SBC.Services.Data.Notifications
{
    using System.Threading.Tasks;

    using SBC.Common;

    public interface INotificationsService
    {
        Task<Result> GetAllByEmailAsyc(string email);

        Task<Result> AddAsync(string email, string message);

        Task DeleteAsync(int id);
    }
}
