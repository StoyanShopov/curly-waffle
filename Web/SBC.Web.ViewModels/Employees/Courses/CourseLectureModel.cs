namespace SBC.Web.ViewModels.Employees.Courses
{
    using AutoMapper;
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class CourseLectureModel : IMapFrom<Lecture>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string LectureName { get; set; }

        public string LectureDescription { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<CourseLecture, CourseLectureModel>()
               .ForMember(
               l => l.Id,
               l => l.MapFrom(l => l.LectureId));
        }
    }
}
