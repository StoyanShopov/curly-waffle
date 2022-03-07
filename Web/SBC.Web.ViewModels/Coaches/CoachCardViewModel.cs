namespace SBC.Web.ViewModels.Coaches
{
    using System.Collections.Generic;

    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class CoachCardViewModel : IMapFrom<Coach>
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public decimal PricePerSession { get; set; }

        public string CompanyLogoUrl { get; set; }

        public string CategoryByDefault { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

        public ICollection<LanguageViewModel> Languages { get; set; } = new List<LanguageViewModel>();

        public bool IsActive { get; set; }
    }
}
