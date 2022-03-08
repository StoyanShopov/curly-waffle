namespace SBC.Web.ViewModels.BusinessOwner.Employees
{
    using System.Collections.Generic;

    public class EmployeesViewModel
    {
        public IEnumerable<EmployeeViewModel> Portions { get; set; }

        public bool ViewMoreAvailable { get; set; }

        public int Count { get; set; }
    }
}
