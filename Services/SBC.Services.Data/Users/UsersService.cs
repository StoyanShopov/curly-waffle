namespace SBC.Services.Data.Users
{
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Common.Extensions;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Companies;
    using SBC.Services.Identity.Contracts;
    using SBC.Services.Mapping;

    using SBC.Web.ViewModels.User;

    using static SBC.Common.ErrorMessageConstants.User;
    using static SBC.Common.GlobalConstants.RolesNamesConstants;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> applicationUsers;
        private readonly ICompaniesService companiesService;
        private readonly IIdentitiesService identitiesService;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersService(
            IDeletableEntityRepository<ApplicationUser> applicationUser,
            ICompaniesService companyService,
            IIdentitiesService identitiesService,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            this.applicationUsers = applicationUser;
            this.companiesService = companyService;
            this.identitiesService = identitiesService;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<Result> RegisterAsync(RegisterInputModel model)
        {
            var emailExists = await this.ExistsByEmailAsync(model.Email);

            if (emailExists)
            {
                var error = string.Format(EmailExists, model.Email);

                return new ErrorModel(HttpStatusCode.BadRequest, error);
            }

            var (firstName, lastName) = model.FullName.GetNames();

            var companyExists = await this.companiesService.ExistsByNameAsync(model.CompanyName);

            if (!companyExists)
            {
                var error = string.Format(CompanyExists, model.CompanyName);

                return new ErrorModel(HttpStatusCode.BadRequest, error);
            }

            var companyId = await this.companiesService.GetIdByNameAsync(model.CompanyName);

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

        public async Task<Result> LoginAsync(LoginInputModel model, string secret)
        {
            var user = await this.applicationUsers
                .AllAsNoTracking()
                .Include(au => au.Roles)
                .FirstOrDefaultAsync(u => u.NormalizedEmail == model.Email.ToUpper());

            if (user == null)
            {
                return new ErrorModel(HttpStatusCode.Unauthorized, InvalidPassOrEmail);
            }

            var isPasswordValid = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (!isPasswordValid)
            {
                return new ErrorModel(HttpStatusCode.Unauthorized, InvalidPassOrEmail);
            }

            var roleId = user.Roles.FirstOrDefault().RoleId;
            var applicationRole = await this.roleManager.Roles.FirstOrDefaultAsync(r => r.Id == roleId);

            var jwt = this.identitiesService.GenerateJwt(secret, user.Id, user.UserName, applicationRole.Name);

            return new ResultModel(new { JWT = jwt });
        }

        public async Task<Result> EditAsync(EditProfileInputModel inputModelUser, string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return new ErrorModel(HttpStatusCode.Unauthorized, errors: NotExistsUser);
            }

            // TODO: user.Email = mapModel.Email;
            user.FirstName = inputModelUser.Fullname.Split(" ")[0];
            user.LastName = inputModelUser.Fullname.Split(" ")[1];
            user.ProfileSummary = inputModelUser.ProfileSummary;
            user.PhotoUrl = inputModelUser.PhotoUrl;

            var result = await this.userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return result.Succeeded;
            }

            return new ErrorModel(HttpStatusCode.BadRequest, result.Errors);
        }

        public async Task<Result> GetUserDataAsync<TModel>(string userId)
        {
            var result = await this.applicationUsers
                 .AllAsNoTracking()
                 .Include(x => x.Company)
                 .Where(u => u.Id == userId)
                 .To<TModel>()
                 .FirstOrDefaultAsync();

            return new ResultModel(result);
        }

        public async Task<TModel> GetByEmailAsync<TModel>(string email)
            => await this.applicationUsers
                .AllAsNoTracking()
                .Where(u => u.NormalizedEmail == email.ToUpper())
                .To<TModel>()
                .FirstOrDefaultAsync();

        public async Task<bool> ExistsByFullNameByEmailAsync(string fullName, string email)
            => await this.applicationUsers
                .AllAsNoTracking()
                .AnyAsync(u => u.NormalizedEmail == email.ToUpper() &&
                    (u.FirstName + ' ' + u.LastName) == fullName.ToLower());

        public async Task<bool> ExistsByEmailAsync(string email)
            => await this.applicationUsers
                .AllAsNoTracking()
                .AnyAsync(u => u.NormalizedEmail == email.ToUpper());

        public int GetCompanyId(string userId)
        {
            var companyId = this.applicationUsers
                .AllAsNoTracking()
                .Where(x => x.Id == userId)
                .Select(x => x.CompanyId)
                .FirstOrDefault();

            return (int)companyId;
        }
    }
}
