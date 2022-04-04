namespace SBC.Services.Data.Notifications
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Companies;
    using SBC.Services.Data.Users;
    using SBC.Services.Mapping;
    using SBC.Web.ViewModels.Notification;
    using SBC.Web.ViewModels.User;

    public class NotificationsService : INotificationsService
    {
        private readonly IDeletableEntityRepository<Notification> notificationsRepository;
        private readonly IUsersService usersService;
        private readonly ICompaniesService companiesService;

        public NotificationsService(
            IDeletableEntityRepository<Notification> notificationsRepository,
            IUsersService usersService,
            ICompaniesService companiesService)
        {
            this.notificationsRepository = notificationsRepository;
            this.usersService = usersService;
            this.companiesService = companiesService;
        }

        public async Task<Result> GetAllByEmailAsync(string email)
        {
            var result = await this.notificationsRepository
                .AllAsNoTracking()
                .Where(n => n.UserEmail.ToLower() == email.ToLower())
                .To<NotificationDetailsViewModel>()
                .ToListAsync();

            return new ResultModel(result);
        }

        public async Task<Result> CreateAsync(
            string uniqueGroupKey, 
            string userEmail, 
            string message)
        {
            var user = await this.usersService.GetByEmailAsync<UserConnection>(userEmail);

            var emails = await this.companiesService.GetAllEmployeesAsync(user.CompanyName);

            foreach (var email in emails)
            {
                var notification = new Notification
                {
                    UniqueGroupKey = uniqueGroupKey,
                    UserEmail = email,
                    Message = message,
                };

                await this.notificationsRepository.AddAsync(notification);
            }

            await this.notificationsRepository.SaveChangesAsync();

            return true;
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var notification = await this.notificationsRepository
                .AllAsNoTracking()
                .FirstOrDefaultAsync(n => n.Id == id);

            if (notification is not null)
            {
                this.notificationsRepository.Delete(notification);
                await this.notificationsRepository.SaveChangesAsync();
            }

            return true;
        }

        public async Task<Result> DeleteAsync(string uniqueGroupKey, string email)
        {
            var notification = await this.notificationsRepository
                .AllAsNoTracking()
                .FirstOrDefaultAsync(n =>
                    n.UniqueGroupKey == uniqueGroupKey
                    && n.UserEmail == email);

            if (notification is not null)
            {
                this.notificationsRepository.Delete(notification);
                await this.notificationsRepository.SaveChangesAsync();
            }

            return true;
        }
    }
}
