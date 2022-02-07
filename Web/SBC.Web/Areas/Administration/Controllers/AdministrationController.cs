namespace SBC.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SBC.Common;
    using SBC.Web.Controllers;

    using static SBC.Common.GlobalConstants.RolesNamesConstants;

    // [Authorize(Roles = AdministratorRoleName)]
    [Area("Administration")]
    [Route("Administration/[controller]")]
    public abstract class AdministrationController : ApiController
    {
    }
}
