namespace SBC.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SBC.Web.Controllers;

    using static SBC.Common.GlobalConstants.AdministrationConstants;
    using static SBC.Common.GlobalConstants.RolesNamesConstants;

    [Authorize(Roles = AdministratorRoleName)]
    [Area(AreaName)]
    [Route("Administration/[controller]")]
    public abstract class AdministrationController : ApiController
    {
    }
}
