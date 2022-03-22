namespace SBC.Web.ViewModels.BusinessOwner.Employees
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class EmployeeViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
    }
}
