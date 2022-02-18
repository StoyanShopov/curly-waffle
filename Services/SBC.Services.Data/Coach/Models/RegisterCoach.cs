namespace SBC.Services.Data.Coach.Models
{
    using System.ComponentModel.DataAnnotations;

    using SBC.Data.Models;

    using static SBC.Common.GlobalConstants.CoachConstants;

    public class RegisterCoach
    {
        [StringLength(MaxLengthName, MinimumLength = MinLengthName)]
        [RegularExpression(NameRegex)]
        public string FirstName { get; set; }

        [StringLength(MaxLengthName, MinimumLength = MinLengthName)]
        [RegularExpression(NameRegex)]
        public string LastName { get; set; }

        [Required]
        [StringLength(MaxLengthDescription, MinimumLength = MinLengthDescription)]
        public string Description { get; set; }

        [Required]
        [Url]
        public string VideoUrl { get; set; }

        [Range(0, double.MaxValue)]
        public decimal PricePerSession { get; set; }

        [Required]
        [Url]
        public string CalendlyUrl { get; set; }

        [MinLength(MinCountAdd)]
        [MaxLength(MaxCountLanguages)]
        public int[] Languages { get; set; }

        [MinLength(MinCountAdd)]
        public int[] Categories { get; set; }
    }
}
