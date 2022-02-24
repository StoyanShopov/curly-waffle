namespace SBC.Web.ViewModels.Course
{
    public class CreateCourseInputModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal PricePerPerson { get; set; }

        public string PictureUrl { get; set; }

        public string VideoUrl { get; set; }

        public int CategoryId { get; set; }

        public int LanguageId { get; set; }

        public int CoachId { get; set; }
    }
}
