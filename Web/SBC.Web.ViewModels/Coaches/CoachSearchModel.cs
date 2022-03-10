using AutoMapper;
using SBC.Data.Models;
using SBC.Services.Mapping;
using System.Collections.Generic;

namespace SBC.Web.ViewModels.Coaches
{
    public class CoachSearchModel //: IMapFrom<Coach>, IHaveCustomMappings
    {
        public string LastName { get; set; }

        public List<string> Categories { get; set; }

        public List<string> Languages { get; set; }

        public string CompanyName { get; set; }

        public decimal Price { get; set; }

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<Coach, CoachSearchModel>()
        //        .ForMember(d => d.CompanyName, cfg => cfg.MapFrom(s => s.Company.Name));
        //}
    }
}
