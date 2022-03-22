namespace SBC.Web.ViewModels.Employees
{
    using AutoMapper;
    using SBC.Data.Models;
    using SBC.Services.Mapping;
    using System.Collections.Generic;

    public class UserCoachSessionViewModel : IMapFrom<UserCoachSession>, IHaveCustomMappings
    {
        public int CoachId { get; set; }

        public string CoachFirstName { get; set; }

        public string CoachLastName { get; set; }

        public string CoachImageUrl { get; set; }

        public string CoachCompanyLogoUrl { get; set; }

        public decimal CoachPricePerSession { get; set; }

        public ICollection<CategoryCoach> CoachCategory { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Coach, UserCoachSessionViewModel>()
                .ForMember(
                c => c.CoachCategory,
                c => c.MapFrom(c => c.Categories));
        }
    }
}
