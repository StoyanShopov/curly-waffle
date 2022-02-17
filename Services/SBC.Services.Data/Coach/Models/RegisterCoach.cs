namespace SBC.Services.Data.Coach.Models
{
    using System.ComponentModel.DataAnnotations;

    using SBC.Data.Models;

    using static SBC.Common.GlobalConstants.CoachConstants;

    public class RegisterCoach
    {
        [RegularExpression(NameRegex)]
        public string FirstName { get; set; }

        [RegularExpression(NameRegex)]
        public string LastName { get; set; }

        [Required]
        [StringLength(MaxLengthDescription, MinimumLength = MinLengthDescription)]
        public string Description { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        [Range(0, double.MaxValue)]
        public decimal PricePerSession { get; set; }

        [Required]
        public string CalendlyUrl { get; set; }

        [MinLength(MinCountLanguages)]
        [MaxLength(MinCountLanguages)]
        public int[] Languages { get; set; }

        public int[] Categories { get; set; }
    }
}
