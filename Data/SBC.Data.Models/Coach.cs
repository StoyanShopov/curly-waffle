namespace SBC.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using SBC.Data.Common.Models;

    public class Coach : BaseDeletableModel<int>
    {
        public Coach()
        {
            this.Categories = new HashSet<CategoryCoach>();
            this.Languages = new HashSet<LanguageCoach>();
            this.Courses = new HashSet<Course>();
            this.Users = new HashSet<UserCoachSession>();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public decimal PricePerSession { get; set; }

        public string CalendlyUrl { get; set; }

        public int? CompanyId { get; set; }

        public Company Company { get; set; }

        public ICollection<CategoryCoach> Categories { get; set; }

        public ICollection<LanguageCoach> Languages { get; set; }

        public ICollection<Course> Courses { get; set; }

        public ICollection<UserCoachSession> Users { get; set; }
    }
}
