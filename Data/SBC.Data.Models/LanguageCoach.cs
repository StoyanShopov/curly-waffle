namespace SBC.Data.Models
{
    using System;

    using SBC.Data.Common.Models;

    public class LanguageCoach : IDeletableEntity
    {
        public int CoachId { get; set; }

        public Coach Coach { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
