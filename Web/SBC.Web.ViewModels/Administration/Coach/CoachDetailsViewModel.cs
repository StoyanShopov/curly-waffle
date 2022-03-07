namespace SBC.Web.ViewModels.Administration.Coach
{
    using System.Collections.Generic;

    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class CoachDetailsViewModel : IMapFrom<Coach>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public decimal PricePerSession { get; set; }

        public string CalendlyUrl { get; set; }

        public int? CompanyId { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<CategoryCoachViewModel> Categories { get; set; }

        public ICollection<LanguageCoachViewModel> Languages { get; set; }
    }
}
