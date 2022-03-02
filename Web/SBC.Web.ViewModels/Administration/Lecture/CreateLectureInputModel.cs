namespace SBC.Web.ViewModels.Administration.Lecture
{
    using System.ComponentModel.DataAnnotations;

    public class CreateLectureInputModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}
