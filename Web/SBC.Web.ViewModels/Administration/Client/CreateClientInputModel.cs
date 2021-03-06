namespace SBC.Web.ViewModels.Administration.Client
{
    using System.ComponentModel.DataAnnotations;

    public class CreateClientInputModel
    {
        [Required(AllowEmptyStrings = true)]
        [StringLength(30, MinimumLength = 2)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
