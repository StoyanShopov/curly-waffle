﻿namespace SBC.Services.Data.Coach.Models
{
    using System.ComponentModel.DataAnnotations;

    using static SBC.Common.GlobalConstants.CoachConstants;

    public class UpdateCoachModel
    {
        public int CoachId { get; set; }

        [Required]
        [StringLength(MaxLengthName, MinimumLength = MinLengthName)]
        [RegularExpression(NameRegex, ErrorMessage = NameRegexMessage)]
        public string Description { get; set; }

        [Required]
        [StringLength(MaxLengthName, MinimumLength = MinLengthName)]
        [RegularExpression(NameRegex, ErrorMessage = NameRegexMessage)]
        [Url]
        public string VideoUrl { get; set; }

        [Range(0, double.MaxValue)]
        public decimal PricePerSession { get; set; }

        [Required]
        [Url]
        public string CalendlyUrl { get; set; }

        [MinLength(MinCountUpdate)]
        [MaxLength(MaxCountLanguages)]
        public LanguageImportId[] Languages { get; set; }

        [MinLength(MinCountUpdate)]
        public CategoryImportId[] Categories { get; set; }
    }
}