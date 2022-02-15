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
    using SBC.Services.Data.Company.Contracts;
    using SBC.Services.Data.User.Contracts;
    using SBC.Services.Data.User.Models;
    using SBC.Services.Identity.Contracts;

    using static SBC.Common.GlobalConstants.RolesNamesConstants;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> applicationUser;
        private readonly ICompanyService companyService;
        private readonly IIdentityService identityService;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(
            IDeletableEntityRepository<ApplicationUser> applicationUser,
            ICompanyService companyService,
            IIdentityService identityService,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            this.applicationUser = applicationUser;
            this.companyService = companyService;
            this.identityService = identityService;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<Result> Register(RegisterServiceModel model)
        {
            var emailExists = await this.NoTrackUserExistsByEmailAsync(model.Email);

            if (emailExists)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, $"Email '{model.Email}' is already taken.");
            }

            var (firstName, lastName) = GetNames(model.FullName);

            var companyExists = await this.companyService.ExistsByNameAsync(model.CompanyName);

            if (!companyExists)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, $"Company '{model.CompanyName}' is not registered.");
            }

            var companyId = await this.companyService.NoTrackGetCompanyByNameAsync(model.CompanyName);

            var user = new ApplicationUser
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = model.Email,
                Email = model.Email,
                CompanyId = companyId,
            };

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
            var user = await this.NoTrackGetByEmailAsync(model.Email);

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

        public async Task<bool> NoTrackUserExistsByEmail(string email)
            => await this.applicationUser
                .AllAsNoTracking()
                .AnyAsync(u => u.NormalizedEmail == email.ToUpper());

        private static (string FirstName, string LastName) GetNames(string fullName)
        {
            var fullNameArray = GetEssence(fullName);

            var firstName = fullNameArray.First().ToLower();
            var lastName = fullNameArray.Last().ToLower();

            return (firstName, lastName);
        }

        private static string[] GetEssence(string fullName)
        {
            var fullNameArgsBySpace = fullName.Split(' ');
            var fullNameArgs = fullNameArgsBySpace.Where(n => !string.IsNullOrWhiteSpace(n.ToString()));
            var fullNameText = string.Join(" ", fullNameArgs);
            var fullNameArr = fullNameText.Split(' ', 2);

            return fullNameArr;
        }

        private async Task<ApplicationUser> NoTrackGetByEmailAsync(string email)
            => await this.applicationUser
                .AllAsNoTracking()
                .Include(au => au.Roles)
                .FirstOrDefaultAsync(u => u.NormalizedEmail == email.ToUpper());

        public async Task<ApplicationUser> AllGetByEmailAndRolesAsync(string email)
            => await this.applicationUser
                .All()
                .Include(au => au.Roles)
                .FirstOrDefaultAsync(u => u.NormalizedEmail == email.ToUpper());

        public async Task<ApplicationUser> AllGetByEmailAsync(string email)
            => await this.applicationUser
                .All()
                .FirstOrDefaultAsync(u => u.NormalizedEmail == email.ToUpper());

        public async Task<bool> NoTrackUserExistsByEmailAsync(string email)
            => await this.applicationUser
                .AllAsNoTracking()
                .AnyAsync(u => u.NormalizedEmail == email.ToUpper());

        // public async Task<bool> NoTrackUserExistsByEmailByFullNameAsync(string email, string fullName)
        //    => await this.applicationUser
        //        .AllAsNoTracking()
        //        .AnyAsync(u => u.NormalizedEmail == email.ToUpper() && u.FullName == fullName.ToLower());
    }
}
