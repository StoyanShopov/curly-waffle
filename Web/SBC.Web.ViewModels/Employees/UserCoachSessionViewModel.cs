namespace SBC.Web.ViewModels.Employees
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class UserCoachSessionViewModel : IMapFrom<UserCoachSession>
    {
        public int CoachId { get; set; }

        public string CoachFirstName { get; set; }

        public string CoachLastName { get; set; }

        public string CoachImageUrl { get; set; }

        public string CoachCompanyLogoUrl { get; set; }

        public decimal CoachPricePerSession { get; set; }

        public string Date { get; set; }
    }
}
