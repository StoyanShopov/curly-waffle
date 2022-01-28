namespace SBC.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using SBC.Common;

    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {

        protected async Task<IActionResult> GenericResponse(Result result) 
        {
            if (result.Succeeded)
            {
                return this.Ok(result.Data);
            }

            return this.BadRequest(result.Error);
        }
    }
}
