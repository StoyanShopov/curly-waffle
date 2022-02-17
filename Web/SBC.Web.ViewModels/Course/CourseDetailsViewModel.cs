namespace SBC.Web.ViewModels.Course
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class CourseDetailsViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
