namespace SBC.Web.Infrastructure.MapperConfig
{
    using AutoMapper;
    using SBC.Data.Models;
    using SBC.Services.Data.Admin.Models;
    using SBC.Web.ViewModels.Administration;
    using System;

    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            this.CreateMap<EditProfileServiceModel, ApplicationUser>()
                .ForMember(c => c.FirstName, cfg => cfg.MapFrom(c => this.GetName(c.Fullname, 0)))
                .ForMember(c => c.LastName, cfg => cfg.MapFrom(c => this.GetName(c.Fullname, 1)));
            this.CreateMap<ApplicationUser, AdminViewModel>()
                       .ForMember(c => c.Fullname, cfg => cfg.MapFrom(c => c.FirstName + ' ' + c.LastName));
        }

        private string GetName(string fullname, int v)
        {
            string[] result = fullname.Split(" ");
            return result[v];
        }
    }
}
