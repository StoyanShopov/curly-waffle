namespace SBC.Web.Areas.BusinessOwner.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SBC.Web.Controllers;

    using static SBC.Common.GlobalConstants.RolesNamesConstants;

    // [Authorize(Roles = CompanyOwnerRoleName)]
    [Area("BusinessOwner")]
    [Route("manager/[controller]")] // check
    public class BusinessOwnerController : ApiController
    {
    }
}
