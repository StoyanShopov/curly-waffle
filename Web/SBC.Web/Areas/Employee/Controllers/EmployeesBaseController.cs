namespace SBC.Web.Areas.Employee.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SBC.Web.Controllers;

    using static SBC.Common.GlobalConstants.RolesNamesConstants;

    [Authorize(Roles = "Employee")]
    [Area("Employee")]
    public class EmployeesBaseController : ApiController
    {
    }
}
