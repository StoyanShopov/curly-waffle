namespace SBC.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;

    using static SBC.Web.ViewModels.ValidationConstants.ApplicationUser;

    public class RegisterInputModel
    {
        [Required]
        public string CompanyName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = true)]
        [RegularExpression(FullNameRegex, ErrorMessage = FullNameError)]
        public string FullName { get; set; }

        [Required]
        [Compare(nameof(ConfirmPassword))]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}
