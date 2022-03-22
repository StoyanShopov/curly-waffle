namespace SBC.Web.ViewModels.Notification
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class NotificationDetailsViewModel : IMapFrom<Notification>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }
    }
}
