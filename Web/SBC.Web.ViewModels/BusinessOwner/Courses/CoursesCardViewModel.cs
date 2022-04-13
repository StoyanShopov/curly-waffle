namespace SBC.Web.ViewModels.BusinessOwner.Courses
{
    using System.Collections.Generic;

    public class CoursesCardViewModel
    {
        public bool ViewMoreAvailable { get; set; }

        public IEnumerable<CourseCardViewModel> Portions { get; set; }
    }
}
