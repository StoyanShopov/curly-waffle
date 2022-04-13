namespace SBC.Web.ViewModels.Employees.Dashboard
{
    using System.Collections.Generic;

    using SBC.Web.ViewModels.Employees.Coaches;
    using SBC.Web.ViewModels.Employees.Courses;

    public class DashboardViewModel
    {
        public ICollection<UserCoachSessionViewModel> UserCoachSessions { get; set; }

        public ICollection<UserCourseViewModel> UserCourses { get; set; }
    }
}
