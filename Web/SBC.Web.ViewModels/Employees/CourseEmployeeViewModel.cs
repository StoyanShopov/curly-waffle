namespace SBC.Web.ViewModels.Employees
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class CourseEmployeeViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CategoryName { get; set; }

        public string PictureUrl { get; set; }

        public string CoachFullName { get; set; }

        public int LecturesCount { get; set; }

        public string CompanyLogoUrl { get; set; }

        public bool IsEnrolled { get; set; }
    }
}
