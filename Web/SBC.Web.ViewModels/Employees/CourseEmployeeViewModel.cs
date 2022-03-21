namespace SBC.Web.ViewModels.Employees
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class CourseEmployeeViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string PictureUrl { get; set; }

        public string CoachName { get; set; }

        public int LecturesCount { get; set; }

        public string CoachCompanyLogoUrl { get; set; }
    }
}
