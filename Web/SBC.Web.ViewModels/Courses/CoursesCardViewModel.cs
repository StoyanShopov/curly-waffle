namespace SBC.Web.ViewModels.Courses
{
    using System.Collections.Generic;

    public class CoursesCardViewModel
    {
        public IEnumerable<CourseCardViewModel> Portions { get; set; }

        public bool ViewMoreAvailable { get; set; }

        public int Count { get; set; }
    }
}
