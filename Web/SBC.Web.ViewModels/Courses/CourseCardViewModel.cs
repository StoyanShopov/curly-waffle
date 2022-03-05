namespace SBC.Web.ViewModels.Courses
{
    using AutoMapper;
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class CourseCardViewModel : IMapFrom<Course>/*, IMapFrom<Coach>,  IHaveCustomMappings*/
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal PricePerPerson { get; set; }

        public int CategoryId { get; set; }

        public int LanguageId { get; set; }

        public string CoachFullName { get; set; }

        public string CompanyLogoUrl { get; set; }

        public bool IsActive { get; set; }

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<Coach, CourseCardViewModel>()
        //                .ForMember(c => c.CoachFullName, cfg => cfg.MapFrom(c => c.FirstName + ' ' + c.LastName));
        //}
    }
}
