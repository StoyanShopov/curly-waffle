namespace SBC.Web.ViewModels.Administration.Coach
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class ListingCoachModel : IMapFrom<Coach>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public decimal PricePerSession { get; set; }

        public string CalendlyUrl { get; set; }

        public int? CompanyId { get; set; }
    }
}
