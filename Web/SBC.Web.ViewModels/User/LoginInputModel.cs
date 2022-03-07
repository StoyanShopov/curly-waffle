namespace SBC.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;

    public class LoginInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
