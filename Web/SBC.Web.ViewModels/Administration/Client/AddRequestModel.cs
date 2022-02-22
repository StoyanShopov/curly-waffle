namespace SBC.Web.ViewModels.Administration.Client
{
    using System.ComponentModel.DataAnnotations;

    public class AddRequestModel
    {
        [Required(AllowEmptyStrings = true)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
