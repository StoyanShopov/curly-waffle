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
        protected IActionResult GenericResponse(Result result)
        {
            if (result.Succeeded)
            {
                return this.Ok(result.Data);
            }

            return result.Error.Item1 switch
            {
                HttpStatusCode.Unauthorized => this.Unauthorized(result.Error.Item2),
                HttpStatusCode.Forbidden => this.Forbid(result.Error.Item2),
                HttpStatusCode.NotFound => this.NotFound(result.Error.Item2),
                _ => this.BadRequest(result.Error),
            };
        }
    }
}
