namespace SBC.Web.Infrastructure.MapperConfig
{
    using AutoMapper;
    using SBC.Data.Models;
    using SBC.Web.ViewModels.Administration;

    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            this.CreateMap<ApplicationUser, AdminViewModel>()
                       .ForMember(c => c.Fullname, cfg => cfg.MapFrom(c => c.FirstName + ' ' + c.LastName));
        }
    }
}
