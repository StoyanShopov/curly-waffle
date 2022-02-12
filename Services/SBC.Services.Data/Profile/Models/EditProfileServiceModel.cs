namespace SBC.Services.Data.Admin.Models
{
    using Microsoft.AspNetCore.Http;

    public class EditProfileServiceModel
    {
        public string Fullname { get; set; }

        public string Email { get; set; }

        public string ProfileSummary { get; set; }

        public IFormFile PhotoUrl { get; set; }
    }
}
