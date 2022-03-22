namespace SBC.Web.ViewModels.Employees
{
    using System.Collections.Generic;

    public class DashboardViewModel
    {
        public ICollection<UserCoachSessionViewModel> UserCoachSessions { get; set; }

        public ICollection<UserCourseViewModel> UserCourses { get; set; }
    }
}
