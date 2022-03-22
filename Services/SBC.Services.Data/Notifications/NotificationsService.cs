namespace SBC.Services.Data.Notifications
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;

    public class NotificationsService : INotificationsService
    {
        private readonly IDeletableEntityRepository<Notification> notificationRepository;

        public NotificationsService(IDeletableEntityRepository<Notification> notificationRepository)
        {
            this.notificationRepository = notificationRepository;
        }

        public async Task<Result> GetAllByEmailAsyc(string email)
        {
            var result = await this.notificationRepository
                .AllAsNoTracking()
                .Where(n => n.UserEmail.Normalize() == email.Normalize())
                .ToListAsync();

            return new ResultModel(result);
        }

        public async Task AddAsync(string email, string message)
        {
            var notification = new Notification
            {
                UserEmail = email,
                Message = message,
            };

            await this.notificationRepository.AddAsync(notification);
            await this.notificationRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var notification = await this.notificationRepository
                .AllAsNoTracking()
                .FirstOrDefaultAsync(n => n.Id == id);

            this.notificationRepository.Delete(notification);
            await this.notificationRepository.SaveChangesAsync();
        }
    }
}
