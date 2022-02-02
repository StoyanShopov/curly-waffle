namespace SBC.Data.Models
{
    using System;

    using SBC.Data.Common.Models;

    public class CategoryCoach : IDeletableEntity
    {
        public int CoachId { get; set; }

        public Coach Coach { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
