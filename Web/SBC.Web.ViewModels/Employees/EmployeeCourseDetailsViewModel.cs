namespace SBC.Web.ViewModels.Employees
{
    using System.ComponentModel.DataAnnotations;

    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class EmployeeCourseDetailsViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        [Range(1, int.MaxValue)]
        public int CoachId { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        [Range(1, int.MaxValue)]
        public int LanguageId { get; set; }

        [Required]
        public string CoachFirstName { get; set; }

        [Required]
        public string CoachLastName { get; set; }

        [Required]
        public string CoachCompanyName { get; set; }

        [Required]
        public string CoachDescription { get; set; }

        public string CoachImageUrl { get; set; }
    }
}
