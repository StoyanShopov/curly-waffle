namespace SBC.Web.Controllers
{
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
                System.Net.HttpStatusCode.Unauthorized => this.Unauthorized(result.Error.Item2),
                System.Net.HttpStatusCode.Forbidden => this.Forbid(result.Error.Item2),
                System.Net.HttpStatusCode.NotFound => this.Unauthorized(result.Error.Item2),
                _ => this.BadRequest(result.Error),
            };
        }
    }
}
