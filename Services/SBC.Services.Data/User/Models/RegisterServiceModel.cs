namespace SBC.Services.Data.User.Models
{
    public class RegisterServiceModel
    {
        public string CompanyName { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
