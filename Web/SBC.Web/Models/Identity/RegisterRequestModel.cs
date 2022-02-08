namespace SBC.Web.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterRequestModel
    {
        [Required]
        public string CompanyName { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required(AllowEmptyStrings = true)]
        [RegularExpression(@" *([A-za-z]{2,}) +([A-za-z]{2,}) *", ErrorMessage = $"Full Name is invalid. Must contain at least two separate names with only letters.")]
        public string FullName { get; init; }

        [Required]
        [Compare(nameof(ConfirmPassword))]
        public string Password { get; init; }

        [Required]
        public string ConfirmPassword { get; init; }
    }
}
