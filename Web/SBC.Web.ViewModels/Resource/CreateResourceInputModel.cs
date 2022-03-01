namespace SBC.Services.Data.Resource.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CreateResourceInputModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string FileUrl { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Size { get; set; }

        [Required]
        public string FileType { get; set; }

        [Required]
        public string LectureId { get; set; }
    }
}
