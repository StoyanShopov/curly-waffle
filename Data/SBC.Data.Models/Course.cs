namespace SBC.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using SBC.Data.Common.Models;

    public class Course : BaseDeletableModel<int>
    {
        public Course()
        {
            this.Users = new HashSet<UserCourse>();
            this.Lectures = new HashSet<CourseLecture>();
        }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal PricePerPerson { get; set; }

        public string PictureUrl { get; set; }

        public string VideoUrl { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }

        public int CoachId { get; set; }

        public Coach Coach { get; set; }

        public ICollection<UserCourse> Users { get; set; }

        public ICollection<CourseLecture> Lectures { get; set; }
    }
}
