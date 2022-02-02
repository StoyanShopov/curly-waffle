namespace SBC.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using SBC.Data.Common.Models;

    public class Resource : BaseDeletableModel<string>
    {
        public Resource()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Name { get; set; }

        public string FileUrl { get; set; }

        public int Size { get; set; }

        public FileType FileType { get; set; }

        public string LectureId { get; set; }

        public Lecture Lecture { get; set; }
    }
}
