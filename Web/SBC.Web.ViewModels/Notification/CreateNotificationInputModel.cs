namespace SBC.Web.ViewModels.Notification
{
    using System.ComponentModel.DataAnnotations;

    public class CreateNotificationInputModel
    {
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Message { get; set; }
    }
}
