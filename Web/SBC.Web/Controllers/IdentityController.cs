namespace SBC.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using SBC.Common;
    using SBC.Data.Models;
    using SBC.Services.Data.User.Contracts;
    using SBC.Services.Data.User.Models;
    using SBC.Services.Identity.Contracts;
    using SBC.Web.Models.Identity;

    public class IdentityController : ApiController
    {
        private readonly IIdentityService identityService;
        private readonly AppSettings appSettings;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;

        public IdentityController(
            IIdentityService identityService,
            IOptions<AppSettings> appSettings,
            UserManager<ApplicationUser> userManager,
            IUserService userService)
        {
            this.identityService = identityService;
            this.appSettings = appSettings.Value;
            this.userManager = userManager;
            this.userService = userService;
        }
        [HttpGet]
        [Route("dgd")]
        public async Task<IActionResult> Index() {
            return this.Ok("Hello");
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<IActionResult> Register(RegisterRequestModel model)
        {
            //Todo all fields rules and catch confirm password

            RegisterServiceModel serviceModel = new()
            {
                FullName = model.FullName,
                CompanyName = model.CompanyName,
                Email = model.Email,
                Password = model.Password,
            };
            Result result =await this.userService.Register(serviceModel);
            return this.GenericResponse(result);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
        {
            var user = await this.userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return this.Unauthorized();
            }

            var isPasswordValid = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (!isPasswordValid)
            {
                return this.Unauthorized();
            }

            var jwt = this.identityService.GenerateJwt(this.appSettings.Secret, user.Id, user.UserName);

            return new LoginResponseModel { JWT = jwt };
        }
    }
}
