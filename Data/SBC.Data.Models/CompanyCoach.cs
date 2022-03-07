namespace SBC.Data.Models
{
    using System;

    using SBC.Data.Common.Models;

    public class CompanyCoach : IDeletableEntity
    {
        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public int CoachId { get; set; }

        public Coach Coach { get; set; }

        public DateTime HireDate { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
