namespace SBC.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;

    using SBC.Data.Models;
    using SBC.Services.Identity.Contracts;
    using SBC.Web.Models.Identity;

    public abstract class IdentityController : ApiController
    {
        private readonly IIdentityService identityService;
        private readonly ApplicationSettings appSettings;
        private readonly UserManager<ApplicationUser> userManager;

        protected IdentityController(
            IIdentityService identityService,
            IOptions<ApplicationSettings> appSettings,
            UserManager<ApplicationUser> userManager)
        {
            this.appSettings = appSettings.Value;
            this.identityService = identityService;
            this.userManager = userManager;
        }

        public async Task<ActionResult> Register(UserRegisterRequestModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Fullname,
                Email = model.Email,
            };

            // Password is hashed automatically
            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return this.Ok();
            }

            return this.BadRequest(result.Errors);
        }

        public async Task<ActionResult<string>> Login(UserLoginRequestModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.Email);

            if (user == null)
            {
                return this.Unauthorized();
            }

            var password = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (!password)
            {
                return this.Unauthorized();
            }

            var token = this.identityService.GenerateJwt(user, this.appSettings.Secret);

            return token;
        }
    }
}
