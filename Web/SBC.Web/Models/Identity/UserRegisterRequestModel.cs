namespace SBC.Web.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    public class UserRegisterRequestModel
    {
        [Required]
        public string Fullname { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
