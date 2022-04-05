namespace SBC.Web.ViewModels.Company
{
    using System.Collections.Generic;

    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class EmployeesViewModel : IMapFrom<Company>
    {
       

        public IEnumerable<string> EmployeesEmail { get; set; }
    }
}
