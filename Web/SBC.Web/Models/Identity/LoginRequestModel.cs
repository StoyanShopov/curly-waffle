namespace SBC.Web.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    public class LoginRequestModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required]
        public string Password { get; init; }
    }
}
