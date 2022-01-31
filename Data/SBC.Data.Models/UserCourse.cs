namespace SBC.Data.Models
{
    using System;

    using SBC.Data.Common.Models;

    public class UserCourse : IDeletableEntity
    {
        public int CourseId { get; set; }

        public Course Course { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public byte? Grade { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
