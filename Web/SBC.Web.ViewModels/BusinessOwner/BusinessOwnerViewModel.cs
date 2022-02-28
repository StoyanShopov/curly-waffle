namespace SBC.Web.ViewModels.BusinessOwner
{
    using AutoMapper;
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class BusinessOwnerViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Fullname { get; set; }

        public string Email { get; set; }

        public string ProfileSummary { get; set; }

        public string PhotoUrl { get; set; }

        public int CompanyId { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, BusinessOwnerViewModel>()
                        .ForMember(c => c.Fullname, cfg => cfg.MapFrom(c => c.FirstName + ' ' + c.LastName));
        }
    }
}
