// ReSharper disable VirtualMemberCallInConstructor
namespace SBC.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;
    using SBC.Data.Common.Models;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Employees = new HashSet<ApplicationUser>();
            this.Courses = new HashSet<UserCourse>();
            this.Sessions = new HashSet<UserCoachSession>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhotoUrl { get; set; }

        public string ProfileSummary { get; set; }

        public string ManagerId { get; set; }

        public ApplicationUser Manager { get; set; }

        public int? CompanyId { get; set; }

        public Company Company { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<UserCourse> Courses { get; set; }

        public virtual ICollection<ApplicationUser> Employees { get; set; }

        public virtual ICollection<UserCoachSession> Sessions { get; set; }
    }
}
