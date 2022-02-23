namespace SBC.Data.Models
{
    using System;

    using SBC.Data.Common.Models;

    public class CompanyCourse : IDeletableEntity
    {
        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public DateTime PurchaseDate { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
