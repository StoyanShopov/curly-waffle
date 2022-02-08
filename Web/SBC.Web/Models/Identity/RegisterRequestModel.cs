namespace SBC.Web.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    using static SBC.Common.GlobalConstants.ApplicationUserConstants;

    public class RegisterRequestModel
    {
        [Required]
        public string CompanyName { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required(AllowEmptyStrings = true)]
        [RegularExpression(FullNameRegex, ErrorMessage = FullNameError)]
        public string FullName { get; init; }

        [Required]
        [Compare(nameof(ConfirmPassword))]
        public string Password { get; init; }

        [Required]
        public string ConfirmPassword { get; init; }
    }
}
