namespace SBC.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using SBC.Services.Data.Users;
    using SBC.Web.ViewModels.User;

    public class IdentityController : ApiController
    {
        private readonly IUsersService usersService;
        private readonly AppSettings appSettings;

        public IdentityController(IOptions<AppSettings> appSettings, IUsersService userService)
        {
            this.appSettings = appSettings.Value;
            this.usersService = userService;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterInputModel model)
        {
            var result = await this.usersService.RegisterAsync(model);

            return this.GenericResponse(result);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult> Login(LoginInputModel model)
        {
            var result = await this.usersService.LoginAsync(model, this.appSettings.Secret);

            return this.GenericResponse(result);
        }
    }
}
