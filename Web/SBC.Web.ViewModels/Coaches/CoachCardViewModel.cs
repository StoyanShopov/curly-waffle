namespace SBC.Web.ViewModels.Coaches
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using SBC.Data.Models;
    using SBC.Services.Mapping;
    using SBC.Web.ViewModels.Categories;
    using SBC.Web.ViewModels.Languages;

    public class CoachCardViewModel : IMapFrom<Coach>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public decimal PricePerSession { get; set; }

        public string ImageUrl { get; set; }

        public string CompanyLogoUrl { get; set; }

        public string CategoryByDefault { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

        public ICollection<LanguageViewModel> Languages { get; set; } = new List<LanguageViewModel>();

        public bool IsActive { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Coach, CoachCardViewModel>()
                 .ForMember(c => c.FullName, cfg => cfg.MapFrom(v => v.FirstName + " " + v.LastName))
                 .ForMember(c => c.CompanyLogoUrl, cfg => cfg.MapFrom(v => v.Company.Name))
                 .ForMember(c => c.CategoryByDefault, cfg => cfg.MapFrom(v => v.Categories.FirstOrDefault()))
                 .ForMember(c => c.IsActive, cfg => cfg.MapFrom(v => v.ClientCompanies.Any(x => x.CompanyId == v.CompanyId)));

        }
    }
}
