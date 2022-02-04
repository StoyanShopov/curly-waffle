namespace SBC.Web.ViewModels.Course
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class CourseViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal PricePerPerson { get; set; }

        public string VideoUrl { get; set; }

        public int CategoryId { get; set; }

        public int LanguageId { get; set; }

        public int CoachId { get; set; }
    }
}
