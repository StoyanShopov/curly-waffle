namespace SBC.Web.ViewModels.Administration.Lectures
{
    using System.ComponentModel.DataAnnotations;

    using static SBC.Web.ViewModels.ValidationConstants.Lecture;

    public class EditLectureInputModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }
    }
}
