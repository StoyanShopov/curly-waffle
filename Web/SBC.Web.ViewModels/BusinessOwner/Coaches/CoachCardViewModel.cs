namespace SBC.Web.ViewModels.BusinessOwner.Coaches
{
    using System.Collections.Generic;

    using SBC.Data.Models;
    using SBC.Services.Mapping;
    using SBC.Web.ViewModels.Categories;
    using SBC.Web.ViewModels.Languages;

    public class CoachCardViewModel : IMapFrom<Coach>
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public decimal PricePerSession { get; set; }

        public string ImageUrl { get; set; }

        public string CompanyLogoUrl { get; set; }

        public string CategoryByDefault { get; set; }

        public string CalendlyUrl { get; set; }

        public bool IsActive { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

        public ICollection<LanguageViewModel> Languages { get; set; } = new List<LanguageViewModel>();
    }
}
