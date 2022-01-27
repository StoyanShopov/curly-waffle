namespace SBC.Web.Controllers
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using SBC.Data.Models;
    using SBC.Web.Models.Identity;

    public abstract class IdentityController : ApiController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationSettings appSettings;

        protected IdentityController(
            UserManager<ApplicationUser> userManager,
            IOptions<ApplicationSettings> appSettings)
        {
            this.userManager = userManager;
            this.appSettings = appSettings.Value;
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

            // JWT valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }
    }
}
