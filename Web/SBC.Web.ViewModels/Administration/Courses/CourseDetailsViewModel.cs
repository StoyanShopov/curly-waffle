namespace SBC.Web.ViewModels.Administration.Courses
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class CourseDetailsViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal PricePerPerson { get; set; }

        public string PictureUrl { get; set; }

        public string VideoUrl { get; set; }

        public int CoachId { get; set; }

        public int CategoryId { get; set; }

        public int LanguageId { get; set; }

        public string CoachFirstName { get; set; }

        public string CoachLastName { get; set; }

        public string CoachCompanyName { get; set; }

        public string CoachDescription { get; set; }

        public string CoachImageUrl { get; set; }
    }
}
