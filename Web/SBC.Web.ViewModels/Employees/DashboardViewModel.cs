namespace SBC.Web.ViewModels.Employees
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using SBC.Data.Models;

    public class DashboardViewModel
    {
        public ICollection<UserCoachSession> UserCoachSessions { get; set; }

        public ICollection<UserCourse> UserCourses { get; set; }
    }
}
