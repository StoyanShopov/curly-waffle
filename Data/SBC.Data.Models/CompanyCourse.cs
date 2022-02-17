using SBC.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBC.Data.Models
{
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
