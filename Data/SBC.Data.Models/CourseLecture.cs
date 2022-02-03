namespace SBC.Data.Models
{
    using System;

    using SBC.Data.Common.Models;

    public class CourseLecture : IDeletableEntity
    {
        public int CourseId { get; set; }

        public Course Course { get; set; }

        public string LectureId { get; set; }

        public Lecture Lecture { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
