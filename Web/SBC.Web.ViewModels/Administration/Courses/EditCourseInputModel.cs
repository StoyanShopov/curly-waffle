namespace SBC.Web.ViewModels.Administration.Courses
{
    using System.ComponentModel.DataAnnotations;

    using static SBC.Web.ViewModels.ValidationConstants.course;

    public class EditCourseInputModel
    {
        [Required]
        [StringLength(TitleMaxvalue, MinimumLength = TitleMinvalue)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, int.MaxValue)]
        public decimal PricePerPerson { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        [Range(1, int.MaxValue)]
        public int LanguageId { get; set; }

        [Range(1, int.MaxValue)]
        public int CoachId { get; set; }
    }
}
