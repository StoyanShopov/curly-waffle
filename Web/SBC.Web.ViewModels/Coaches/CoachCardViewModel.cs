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

        public ICollection<CategoryCoach> Categories { get; set; }

        public ICollection<LanguageCoach> Languages { get; set; }

        public bool IsActive { get; set; }
    }
}
