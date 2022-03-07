namespace SBC.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using SBC.Data.Common.Models;

    public class Company : BaseDeletableModel<int>
    {
        public Company()
        {
            this.Employees = new HashSet<ApplicationUser>();
            this.ActiveCoaches = new HashSet<CompanyCoach>();
            this.ActiveCourses = new HashSet<CompanyCourse>();
            this.Coaches = new HashSet<Coach>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string LogoUrl { get; set; }

        public ICollection<ApplicationUser> Employees { get; set; }

        public ICollection<Coach> Coaches { get; set; }

        public ICollection<CompanyCourse> ActiveCourses { get; set; }

        public ICollection<CompanyCoach> ActiveCoaches { get; set; }
    }
}
