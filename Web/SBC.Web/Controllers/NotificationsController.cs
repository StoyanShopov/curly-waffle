namespace SBC.Web.Controllers
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Notifications;
    using SBC.Web.ViewModels.Notification;

    public class NotificationsController : ApiController
    {
        private readonly INotificationsService notificationsService;

        public NotificationsController(INotificationsService notificationsService)
        {
            this.notificationsService = notificationsService;
        }

        [HttpGet]
        [Route(nameof(All))]
        public async Task<ActionResult> All([NotNull] [EmailAddress] string email)
        {
            var result = await this.notificationsService
                .GetAllByEmailAsyc(email);

            return this.GenericResponse(result);
        }

        [HttpPost]
        public async Task Create(CreateNotificationInputModel model)
            => await this.notificationsService.AddAsync(
                model.UserEmail,
                model.Message);

        [HttpDelete]
        public async Task Remove(int id)
            => await this.notificationsService
                .DeleteAsync(id);
    }
}
