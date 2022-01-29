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

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> applicationUser;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(IDeletableEntityRepository<ApplicationUser> applicationUser, UserManager<ApplicationUser> userManager)
        {
            this.applicationUser = applicationUser;
            this.userManager = userManager;
        }

        public async Task<Result> Register(RegisterServiceModel model)
        {
            //if (model.Password != model.ConfirmPassword)
            //{
            //    return this.BadRequest($"You gave two diffrent passwords.");
            //}

            var emailExists = await this.UserExistsByEmail(model.Email);

            if (emailExists)
            {
                return new Tuple<HttpStatusCode, string>(HttpStatusCode.BadRequest, $"Email '{model.Email}' is already taken.");
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
                return new Tuple<HttpStatusCode, string>(HttpStatusCode.BadRequest, string.Join("\n", result.Errors));
            }

            return true;
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
