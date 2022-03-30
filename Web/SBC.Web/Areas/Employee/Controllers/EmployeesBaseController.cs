namespace SBC.Web.Areas.Employee.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SBC.Web.Controllers;

    using static SBC.Common.GlobalConstants;

    [Authorize(Roles = RolesNamesConstants.CompanyEmployeeRoleName)]
    [Area("Employee")]
    [Route("employees/[controller]")]
    public abstract class EmployeesBaseController : ApiController
    {
    }
}
