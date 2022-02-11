namespace SBC.Services.Data.Coach.Models
{
    using System.ComponentModel.DataAnnotations;

    using static SBC.Common.GlobalConstants.ApplicationUserConstants;

    public class RegisterCoach
    {
        [RegularExpression(NameRegex)]
        public string FirstName { get; set; }

        [RegularExpression(NameRegex)]
        public string LastName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        public decimal PricePerSession { get; set; }

        [Required]
        public string CalendlyUrl { get; set; }

        public int[] Languiges { get; set; }

        public int[] Categories { get; set; }
    }
}
