namespace SBC.Web.ViewModels.Employees
{
    using System.Collections.Generic;

    using AutoMapper;
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class UserCourseViewModel : IMapFrom<UserCourse>, IHaveCustomMappings
    {
        public int CourseId { get; set; }

        public string CourseTitle { get; set; }

        public string CourseCoachFirstName { get; set; }

        public string CourseCoachLastName { get; set; }

        public string CompanyLogoUrl { get; set; }

        public string CoursePictureUrl { get; set; }

        public string CourseVideoUrl { get; set; }

        public IEnumerable<CourseLectureModel> CourseLectures { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<CourseLecture, UserCourseViewModel>()
              .ForMember(
              c => c.CourseId,
              c => c.MapFrom(c => c.CourseId));

            configuration.CreateMap<UserCourse, UserCourseViewModel>()
                .ForMember(
                c => c.CompanyLogoUrl,
                c => c.MapFrom(c => c.Course.Coach.Company.LogoUrl));
        }
    }
}
