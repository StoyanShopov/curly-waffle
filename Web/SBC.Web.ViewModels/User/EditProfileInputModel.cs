namespace SBC.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;

    public class EditProfileInputModel
    {
        [Required(AllowEmptyStrings = true)]
        [StringLength(30, MinimumLength = 2)]
        public string Fullname { get; set; }

        // TODO: Remove email
        public string Email { get; set; }

        [Required]
        [StringLength(300)]
        public string ProfileSummary { get; set; }

        [Required]
        public string PhotoUrl { get; set; }
    }
}
