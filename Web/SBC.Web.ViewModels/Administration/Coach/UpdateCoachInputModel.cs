namespace SBC.Web.ViewModels.Administration.Coach
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static SBC.Web.ViewModels.Constants.DataModelsConstants.CoachDtoConstants;

    public class UpdateCoachInputModel
    {
        public int CoachId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //[Required]
        //[StringLength(MaxLengthDescription, MinimumLength = MinLengthDescription)]
        public string Description { get; set; }

        //[Required]
        //[Url]
        public string VideoUrl { get; set; }

        //[Range(0, double.MaxValue)]
        public decimal PricePerSession { get; set; }

        //[Required]
        //[Url]
        public string ImageUrl { get; set; }

        //[EmailAddress]
        public string CompanyEmail { get; set; }

        //[Required]
        //[Url]
        public string CalendlyUrl { get; set; }

        //[MinLength(MinCountUpdate)]
        public ICollection<CategoryCoachViewModel> Categories { get; set; }

        //[MinLength(MinCountUpdate)]
        public ICollection<LanguageCoachViewModel> Languages { get; set; }
    }
}
