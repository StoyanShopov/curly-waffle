namespace SBC.Web.ViewModels.Notification
{
    using System.ComponentModel.DataAnnotations;

    public class CreateNotificationInputModel
    {
        public string UniqueGroupKey { get; set; }

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Message { get; set; }
    }
}
