namespace SBC.Services.Data.Notifications
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Mapping;
    using SBC.Web.ViewModels.Notification;

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
                .Where(n => n.UserEmail.ToLower() == email.ToLower())
                .To<NotificationDetailsViewModel>()
                .ToListAsync();

            return new ResultModel(result);
        }

        public async Task<Result> AddAsync(string userEmail, string message)
        {
            var notification = new Notification
            {
                UserEmail = userEmail,
                Message = message,
            };

            await this.notificationRepository.AddAsync(notification);
            await this.notificationRepository.SaveChangesAsync();

            return new ResultModel(notification.Id);
        }

        public async Task DeleteAsync(int id)
        {
            var notification = await this.notificationRepository
                .AllAsNoTracking()
                .FirstOrDefaultAsync(n => n.Id == id);

            if (notification is not null)
            {
                this.notificationRepository.Delete(notification);
                await this.notificationRepository.SaveChangesAsync();
            }
        }
    }
}
