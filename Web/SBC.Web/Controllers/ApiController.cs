namespace SBC.Web.Controllers
{
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Common;

    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        protected ActionResult GenericResponse(Result result)
        {
            if (result.Succeeded)
            {
                if (result.Data != null)
                {
                    return this.Ok(result.Data.Value);
                }

                return this.Ok();
            }

            return result.Errors.Status switch
            {
                HttpStatusCode.Unauthorized => this.Unauthorized(result.Errors),
                HttpStatusCode.Forbidden => this.Forbid(),
                HttpStatusCode.NotFound => this.NotFound(result.Errors),
                _ => this.BadRequest(result.Errors),
            };
        }
    }
}
