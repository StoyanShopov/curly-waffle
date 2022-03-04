namespace SBC.Web.ViewModels.Courses
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class ActiveCourseViewModel : IMapFrom<Course>
    {
        public ActiveCourseViewModel()
        {
            this.IsActive = true;
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal PricePerPerson { get; set; }

        public int CategoryId { get; set; }

        public int LanguageId { get; set; }

        public string CoachName { get; set; }

        public string CompanyLogoUrl { get; set; }

        public bool IsActive { get; set; }
    }
}
