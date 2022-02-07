namespace SBC.Services.Data.User
{
    using System.Linq;
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

    using static SBC.Common.GlobalConstants.RolesNamesConstants;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> applicationUser;
        private readonly IIdentityService identityService;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(
            IDeletableEntityRepository<ApplicationUser> applicationUser,
            IIdentityService identityService,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            this.applicationUser = applicationUser;
            this.identityService = identityService;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<Result> Register(RegisterServiceModel model)
        {
            var emailExists = await this.UserExistsByEmail(model.Email);

            if (emailExists)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, $"Email '{model.Email}' is already taken.");
            }

            // TODO Add CompanyName and FullName
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

            await this.userManager.AddToRoleAsync(user, CompanyEmployeeRoleName);

            return true;
        }

        public async Task<Result> Login(LoginServiceModel model, string secret)
        {
            var user = await this.AllInternalGetByEmailAsync(model.Email);

            if (user == null)
            {
                return new ErrorModel(HttpStatusCode.Unauthorized, "Password/Email is invalid!");
            }

            var isPasswordValid = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (!isPasswordValid)
            {
                return new ErrorModel(HttpStatusCode.Unauthorized, "Password/Email is invalid!");
            }

            var roleId = user.Roles.FirstOrDefault().RoleId;
            var applicationRole = await this.roleManager.Roles.FirstOrDefaultAsync(r => r.Id == roleId);

            var jwt = this.identityService.GenerateJwt(secret, user.Id, user.UserName, applicationRole.Name);

            return new ResultModel(new { JWT = jwt });
        }

        public async Task<bool> UserExistsByEmail(string email)
        {
            var user = await this.applicationUser
                .AllAsNoTracking()
                .FirstOrDefaultAsync(u => u.NormalizedEmail == email.ToUpper());

            return user is not null;
        }

        private async Task<ApplicationUser> AllInternalGetByEmailAsync(string email)
            => await this.applicationUser
                .All()
                .Include(au => au.Roles)
                .FirstOrDefaultAsync(u => u.NormalizedEmail == email.ToUpper());
    }
}
