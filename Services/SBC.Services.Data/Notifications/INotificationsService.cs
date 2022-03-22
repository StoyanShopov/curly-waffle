namespace SBC.Services.Data.Notifications
{
    using System.Threading.Tasks;

    using SBC.Common;

    public interface INotificationsService
    {
        Task<Result> GetAllByEmailAsyc(string email);

        Task AddAsync(string email, string message);

        Task DeleteAsync(int id);
    }
}
