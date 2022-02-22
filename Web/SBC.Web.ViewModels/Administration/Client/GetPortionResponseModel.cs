namespace SBC.Web.ViewModels.Administration.Client
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class GetPortionResponseModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string NormalizedEmail { get; set; }

        public string CompanyName { get; set; }
    }
}
