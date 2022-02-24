namespace SBC.Services.Data.Client
{
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Client.Contracts;
    using SBC.Services.Data.Client.Models;
    using SBC.Services.Data.Company;
    using SBC.Services.Data.User.Contracts;
    using SBC.Services.Mapping;
    using SBC.Web.ViewModels.Administration.Client;

    using static SBC.Common.GlobalConstants.RolesNamesConstants;

    public class ClientService : IClientService
    {
        private const int TakeDefaultValue = 3;

        private readonly IDeletableEntityRepository<ApplicationUser> applicationUser;
        private readonly ICompaniesService companyService;
        private readonly IUserService userService;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public ClientService(
            IDeletableEntityRepository<ApplicationUser> applicationUser,
            ICompaniesService companyService,
            IUserService userService,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            this.applicationUser = applicationUser;
            this.companyService = companyService;
            this.userService = userService;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<Result> AddAsync(AddRequestModel model)
        {
            var emailExists = await this.userService.ExistsByFullNameByEmailAsync(model.FullName, model.Email);

            if (!emailExists)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, $"There is no user with the given '{model.FullName}' and '{model.Email}'.");
            }

            var user = await this.userService.GetByEmailIncludedRolesAndCompanyAsync(model.Email);

            var ownerExists = await this.companyService.ExistsOwnerAsync(user.Company.Name);

            if (ownerExists)
            {
                var error = $"The user's company '{user.Company.Name}' has already a owner.";

                return new ErrorModel(HttpStatusCode.BadRequest, error);
            }

            if (user.Roles.Any())
            {
                var administratorRole = await this.roleManager.FindByNameAsync(AdministratorRoleName);

                if (user.Roles.Any(r => r.RoleId == administratorRole.Id))
                {
                    var error = $"The user is {AdministratorRoleName}. Cannot downgrade to {CompanyOwnerRoleName} role.";

                    return new ErrorModel(HttpStatusCode.BadRequest, error);
                }

                var ownerRole = await this.roleManager.FindByNameAsync(CompanyOwnerRoleName);

                if (user.Roles.Any(r => r.RoleId == ownerRole.Id))
                {
                    var error = $"The user is already an {CompanyOwnerRoleName}.";

                    return new ErrorModel(HttpStatusCode.BadRequest, error);
                }

                var employeeRole = await this.roleManager.FindByNameAsync(CompanyEmployeeRoleName);

                if (user.Roles.Any(r => r.RoleId == employeeRole.Id))
                {
                    await this.userManager.RemoveFromRoleAsync(user, CompanyEmployeeRoleName);
                }
            }

            await this.userManager.AddToRoleAsync(user, CompanyOwnerRoleName);

            return new ResultModel(new AddServiceModel
            {
                Client = new GetPortionServiceModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    NormalizedEmail = user.NormalizedEmail,
                    CompanyName = user.Company?.Name,
                },
            });
        }

        public async Task<Result> GetPortionAsync(int skip = default, int take = TakeDefaultValue)
        {
            var role = await this.roleManager.FindByNameAsync(CompanyOwnerRoleName);

            var portions = await this.applicationUser
                 .AllAsNoTracking()
                 .OrderByDescending(au => au.CreatedOn)
                 .Where(au => au.Roles.Any(r => r.RoleId == role.Id))
                 .Skip(skip)
                 .Take(take)
                 .Include(au => au.Company)
                 .To<GetPortionResponseModel>()
                 .ToListAsync();

            return new ResultModel(new GetPortionsServiceModel
            {
                Portions = portions,
                ViewMoreAvaliable = await this.IsViewMoreAvaliable(skip, take, role.Id),
            });
        }

        private async Task<bool> IsViewMoreAvaliable(int skip, int take, string roleId)
        {
            var clientsCount = await this.applicationUser
                .AllAsNoTracking()
                .Where(au => au.Roles.Any(r => r.RoleId == roleId))
                .CountAsync();

            return (clientsCount - skip - take) > 0;
        }
    }
}
