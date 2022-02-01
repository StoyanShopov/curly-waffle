namespace SBC.Data.Models
{
    using System;

    using SBC.Data.Common.Models;

    public class UserCoachSession : IDeletableEntity
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int CoachId { get; set; }

        public Coach Coach { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
