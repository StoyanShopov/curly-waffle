namespace SBC.Web.Areas.Employee.Controlles
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SBC.Web.Controllers;

    using static SBC.Common.GlobalConstants;

    [Authorize(Roles = RolesNamesConstants.CompanyEmployeeRoleName)]
    [Area("Employee")]
    [Route("api/employees/[controller]")]
    public class EmployeesController : ApiController
    {
    }
}
