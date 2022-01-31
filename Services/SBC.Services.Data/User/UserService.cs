namespace SBC.Services.Data.User
{
    using System;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.User.Contracts;
    using SBC.Services.Data.User.Models;
    using SBC.Services.Identity.Contracts;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> applicationUser;
        private readonly IIdentityService identityService;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(
            IDeletableEntityRepository<ApplicationUser> applicationUser,
            IIdentityService identityService,
            UserManager<ApplicationUser> userManager)
        {
            this.applicationUser = applicationUser;
            this.userManager = userManager;
            this.identityService = identityService;
        }

        public async Task<Result> Register(RegisterServiceModel model)
        {
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

        public async Task<Result> Login(LoginServiceModel model, string secret)
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

            var jwt = this.identityService.GenerateJwt(secret, user.Id, user.UserName);

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
