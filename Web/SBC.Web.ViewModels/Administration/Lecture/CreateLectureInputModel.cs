namespace SBC.Web.ViewModels.Administration.Lecture
{
    public class CreateLectureInputModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CourseId { get; set; }
    }
}
