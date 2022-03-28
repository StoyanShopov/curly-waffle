namespace SBC.Web.ViewModels.User
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class UserConnection : IMapFrom<ApplicationUser>
    {
        public string Email { get; set; }

        public string CompanyName { get; set; }
    }
}
