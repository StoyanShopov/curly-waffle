namespace SBC.Web.ViewModels.Administration.Resources
{
    using System.ComponentModel.DataAnnotations;

    using static SBC.Web.ViewModels.ValidationConstants.Resource;

    public class EditResourceInputModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        public string FileUrl { get; set; }

        [Required]
        [Range(SizeMinLength, SizeMaxLength)]
        public int Size { get; set; }

        [Required]
        public string FileType { get; set; }

        [Required]
        public string LectureId { get; set; }
    }
}
