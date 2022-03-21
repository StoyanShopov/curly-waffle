namespace SBC.Web.Areas.Employees.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SBC.Web.Controllers;

    using static SBC.Common.GlobalConstants.RolesNamesConstants;

    [Authorize(Roles = CompanyEmployeeRoleName)]
    [Area("Employee")]
    public class EmployeesBaseController : ApiController
    {
    }
}
