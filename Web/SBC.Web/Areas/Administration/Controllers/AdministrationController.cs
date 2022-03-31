namespace SBC.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SBC.Web.Controllers;

    using static SBC.Common.GlobalConstants.RolesNamesConstants;

    [Authorize(Roles = AdministratorRoleName)]
    [Area(AdministratorRoleName)]
    [Route($"{AdministratorRoleName}/[controller]")]
    public abstract class AdministrationController : ApiController
    {
    }
}
