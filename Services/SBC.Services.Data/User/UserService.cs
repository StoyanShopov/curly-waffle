namespace SBC.Services.Data.User
{
    using System;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.User.Contracts;
    using SBC.Services.Data.User.Models;
    using SBC.Services.Identity.Contracts;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> applicationUser;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IIdentityService identityService;
        private readonly AppSettings appSettings;

        public UserService(
            IDeletableEntityRepository<ApplicationUser> applicationUser,
            UserManager<ApplicationUser> userManager,
            IIdentityService identityService,
            IOptions<AppSettings> appSettings)
        {
            this.applicationUser = applicationUser;
            this.userManager = userManager;
            this.identityService = identityService;
            this.appSettings = appSettings.Value;
        }

        public async Task<Result> Register(RegisterServiceModel model)
        {
            // if (model.Password != model.ConfirmPassword)
            // {
            //    return this.BadRequest($"You gave two diffrent passwords.");
            // }
            var emailExists = await this.UserExistsByEmail(model.Email);

            if (emailExists)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, $"Email '{model.Email}' is already taken.");
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
                return new ErrorModel(HttpStatusCode.BadRequest, result.Errors);
            }

            return true;
        }

        public async Task<Result> Login(LoginServiceModel model)
        {
            var user = await this.userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return new ErrorModel(HttpStatusCode.Unauthorized, "Password/Email is invalid!");
            }

            var isPasswordValid = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (!isPasswordValid)
            {
                return new ErrorModel(HttpStatusCode.Unauthorized, "Password/Email is invalid!");
            }

            var jwt = this.identityService.GenerateJwt(this.appSettings.Secret, user.Id, user.UserName);

            return new ResultModel(new { JWT = jwt });
        }

        public async Task<bool> UserExistsByEmail(string email)
        {
            var user = await this.applicationUser
                .AllAsNoTracking()
                .FirstOrDefaultAsync(u => u.NormalizedEmail == email.ToUpper());

            return user is not null;
        }
    }
}
