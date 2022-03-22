namespace SBC.Web.ViewModels.Employees
{
    using AutoMapper;
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class UserCourseViewModel : IMapFrom<UserCourse>, IHaveCustomMappings
    {
        public string CourseTitle { get; set; }

        public string CourseCoachFirstName { get; set; }

        public string CourseCoachLastName { get; set; }

        public string CourseCoachCompanyName { get; set; }

        public string CoursePictureUrl { get; set; }

        public int LecturesCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Course, UserCourseViewModel>()
                .ForMember(
                c => c.LecturesCount,
                c => c.MapFrom(c => c.Lectures.Count));
        }
    }
}
