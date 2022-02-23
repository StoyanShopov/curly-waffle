namespace SBC.Web.ViewModels.Course
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class CourseListingViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal PricePerPerson { get; set; }

        public string PictureUrl { get; set; }

        public string CoachFirstName { get; set; }

        public string CoachLastName { get; set; }

        public string CoachCompanyName { get; set; }
    }
}
