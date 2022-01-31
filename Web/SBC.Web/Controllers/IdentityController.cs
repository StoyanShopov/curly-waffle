namespace SBC.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using SBC.Common;
    using SBC.Data.Models;
    using SBC.Services.Data.User.Contracts;
    using SBC.Services.Data.User.Models;
    using SBC.Web.Models.Identity;

    public class IdentityController : ApiController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;
        private readonly AppSettings appSettings;

        public IdentityController(
            IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.Values.SelectMany(x => x.Errors));
            }

            var serviceModel = new RegisterServiceModel()
            {
                FullName = model.FullName,
                CompanyName = model.CompanyName,
                Email = model.Email,
                Password = model.Password,
            };
            Result result = await this.userService.Register(serviceModel);
            return this.GenericResponse(result);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult> Login(LoginRequestModel model)
        {
            var serviceModel = new LoginServiceModel
            {
                Email = model.Email,
                Password = model.Password,
            };

            return this.GenericResponse(await this.userService.Login(serviceModel));
        }
    }
}
