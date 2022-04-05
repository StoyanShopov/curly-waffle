namespace SBC.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;

    using static SBC.Common.ValidationConstant;

    public class EditProfileInputModel
    {
        [Required(AllowEmptyStrings = true)]
        [StringLength(UserConstants.FullnameMaxLength, MinimumLength = UserConstants.FullnameMinLength)]
        public string Fullname { get; set; }

        [Required]
        [StringLength(UserConstants.ProfileSummaryMaxLength)]
        public string ProfileSummary { get; set; }

        public string PhotoUrl { get; set; }
    }
}
