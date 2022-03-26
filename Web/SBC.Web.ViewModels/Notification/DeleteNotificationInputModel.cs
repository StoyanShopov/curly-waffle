namespace SBC.Web.ViewModels.Notification
{
    using System.ComponentModel.DataAnnotations;

    public class DeleteNotificationInputModel
    {
        [Required]
        public string UniqueGroupKey { get; set; }

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
    }
}
