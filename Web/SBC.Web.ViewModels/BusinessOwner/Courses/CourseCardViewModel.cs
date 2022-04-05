namespace SBC.Web.ViewModels.BusinessOwner.Courses
{
    using AutoMapper;
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class CourseCardViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal PricePerPerson { get; set; }

        public string PictureUrl { get; set; }

        public int CategoryId { get; set; }

        public int LanguageId { get; set; }

        public string CoachFullName { get; set; }

        public string CompanyLogoUrl { get; set; }

        public string CategoryName { get; set; }

        public bool IsActive { get; set; }
    }
}
