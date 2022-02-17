using SBC.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBC.Data.Models
{
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
