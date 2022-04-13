namespace SBC.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using SBC.Services.Data.Infrastructures;
    using SBC.Services.Data.Users;
    using SBC.Web.ViewModels.User;

    public class IdentityController : ApiController
    {
        private readonly AppSettings appSettings;
        private readonly IUsersService usersService;

        public IdentityController(IOptions<AppSettings> appSettings, IUsersService userService)
        {
            this.appSettings = appSettings.Value;
            this.usersService = userService;
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> Update(EditProfileInputModel model)
        {
            var result = await this.usersService.UpdateAsync(model, this.User.Id());

            return this.GenericResponse(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await this.usersService.GetUserDataAsync<ProfileViewModel>(this.User.Id());

            return this.GenericResponse(result);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult> Login(LoginInputModel model)
        {
            var result = await this.usersService.LoginAsync(model, this.appSettings.Secret);

            return this.GenericResponse(result);
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterInputModel model)
        {
            var result = await this.usersService.RegisterAsync(model);

            return this.GenericResponse(result);
        }
    }
}
