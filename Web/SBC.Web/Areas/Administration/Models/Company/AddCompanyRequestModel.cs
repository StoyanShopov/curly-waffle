namespace SBC.Web.Areas.Administration.Models.Company
{
    using System.ComponentModel.DataAnnotations;

    public class AddCompanyRequestModel
    {
        [Required(AllowEmptyStrings = true)]
        public string Name { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required]
        public string LogoUrl { get; init; }
    }
}
