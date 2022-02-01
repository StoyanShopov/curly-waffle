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

        [Required]
        public string FullName { get; init; }

        [Required]
        [Compare(nameof(ConfirmPassword))]
        public string Password { get; init; }

        [Required]
        public string ConfirmPassword { get; init; }
    }
}
