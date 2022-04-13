namespace SBC.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;

    using static SBC.Web.ViewModels.ValidationConstants;

    public class EditProfileInputModel
    {
        [Required(AllowEmptyStrings = true)]
        [StringLength(ApplicationUser.FullnameMaxLength, MinimumLength = ApplicationUser.FullnameMinLength)]
        public string Fullname { get; set; }

        [Required]
        [StringLength(ApplicationUser.ProfileSummaryMaxLength)]
        public string ProfileSummary { get; set; }

        public string PhotoUrl { get; set; }
    }
}
