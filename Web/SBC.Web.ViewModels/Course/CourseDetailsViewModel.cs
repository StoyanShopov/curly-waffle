namespace SBC.Web.ViewModels.Course
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class CourseDetailsViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CoachFirstName { get; set; }

        public string CoachLastName { get; set; }

        public string CoachCompanyName { get; set; }

        public string CoachDescription { get; set; }
    }
}
