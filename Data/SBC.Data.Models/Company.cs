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
            this.Coaches = new HashSet<Coach>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string LogoUrl { get; set; }

        public ICollection<ApplicationUser> Employees { get; set; }

        public ICollection<Coach> Coaches { get; set; }
    }
}
