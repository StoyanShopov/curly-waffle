namespace SBC.Services.Data.Coach.Models
{
    using System.ComponentModel.DataAnnotations;

    using SBC.Data.Models;

    using static SBC.Common.GlobalConstants.CoachConstants;

    public class RegisterCoach
    {
        [Required]
        [StringLength(MaxLengthName, MinimumLength = MinLengthName)]
        [RegularExpression(NameRegex, ErrorMessage = NameRegexMessage)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(MaxLengthName, MinimumLength = MinLengthName)]
        [RegularExpression(NameRegex, ErrorMessage = NameRegexMessage)]
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
        public LanguageImportId[] Languages { get; set; }

        [MinLength(MinCountAdd)]
        public CategoryImportId[] Categories { get; set; }
    }
}
