namespace SBC.Web.ViewModels.Administration.Lecture
{
    using System.ComponentModel.DataAnnotations;

    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class LectureViewModel : IMapFrom<Lecture>
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
