namespace SBC.Web.ViewModels.Administration.Lectures
{
    using System.ComponentModel.DataAnnotations;

    public class EditLectureInputModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
