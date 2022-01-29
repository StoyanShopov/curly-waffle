namespace SBC.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;

    using SBC.Data.Models;
    using SBC.Services.Data.User.Contracts;
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

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterRequestModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return this.BadRequest($"You gave two diffrent passwords.");
            }

            var emailExists = await this.userService.UserExistsByEmail(model.Email);

            if (emailExists)
            {
                return this.BadRequest($"Email '{model.Email}' is already taken.");
            }

            var user = new ApplicationUser
            {
                UserName = model.FullName,
                Email = model.Email,
            };

            // Password is hashed automatically
            var result = await this.userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return this.BadRequest(result.Errors);
            }

            return this.Ok();
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
