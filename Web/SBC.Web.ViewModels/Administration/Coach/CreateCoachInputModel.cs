namespace SBC.Web.ViewModels.Administration.Coach
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static SBC.Web.ViewModels.Constants.DataModelsConstants.CoachDtoConstants;

    public class CreateCoachInputModel
    {
        [Required]
        [StringLength(MaxLengthName, MinimumLength = MinLengthName)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(MaxLengthName, MinimumLength = MinLengthName)]
        public string LastName { get; set; }

        [Required]
        [StringLength(MaxLengthDescription, MinimumLength = MinLengthDescription)]
        public string Description { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [EmailAddress]
        public string CompanyEmail { get; set; }

        [Required]
        [Url]
        public string VideoUrl { get; set; }

        [Range(0, double.MaxValue)]
        public decimal PricePerSession { get; set; }

        [Required]
        [Url]
        public string CalendlyUrl { get; set; }

        [MinLength(MinCountAdd)]
        public ICollection<LanguageCoachViewModel> Languages { get; set; }

        [MinLength(MinCountAdd)]
        public ICollection<CategoryCoachViewModel> Categories { get; set; }
    }
}
