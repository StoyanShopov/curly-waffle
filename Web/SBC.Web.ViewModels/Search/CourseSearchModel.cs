namespace SBC.Web.ViewModels.Search
{
    using AutoMapper;
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class CourseSearchModel : IMapFrom<Course>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal PricePerPerson { get; set; }

        public string PictureUrl { get; set; }

        public int? CategoryId { get; set; }

        public int? LanguageId { get; set; }

        public string CoachFullName { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Course, CourseSearchModel>()
                 .ForMember(x => x.CategoryName, cfg => cfg.MapFrom(c => c.Category.Name))
                 .ForMember(x => x.CoachFullName, cfg => cfg.MapFrom(c => c.Coach.FirstName + " " + c.Coach.LastName));
        }
    }
}
