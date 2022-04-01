namespace SBC.Web.ViewModels.Administration.Courses
{
    using System.ComponentModel.DataAnnotations;

    using static SBC.Web.ViewModels.ValidationConstants.course;

    public class CreateCourseInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }

        [Range(RangeMinValue, int.MaxValue)]
        public decimal PricePerPerson { get; set; }

        [Required]
        [Url]
        public string PictureUrl { get; set; }

        [Required]
        [Url]
        public string VideoUrl { get; set; }

        [Range(RangeMinValue, int.MaxValue)]
        public int CategoryId { get; set; }

        [Range(RangeMinValue, int.MaxValue)]
        public int LanguageId { get; set; }

        [Range(RangeMinValue, int.MaxValue)]
        public int CoachId { get; set; }
    }
}
