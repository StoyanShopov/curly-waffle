namespace SBC.Web.ViewModels.Administration.Company
{
    using System.ComponentModel.DataAnnotations;

    public class AddRequestModel
    {
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string LogoUrl { get; set; }
    }
}
