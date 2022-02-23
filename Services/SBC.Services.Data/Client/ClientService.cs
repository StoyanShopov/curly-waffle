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
    using SBC.Services.Data.Company;
    using SBC.Services.Data.User.Contracts;
    using SBC.Services.Mapping;
    using SBC.Web.ViewModels.Administration.Client;

    using static SBC.Common.GlobalConstants.RolesNamesConstants;

    public class ClientService : IClientService
    {
        private const int TakeDefaultValue = 3;

        private readonly IDeletableEntityRepository<ApplicationUser> applicationUser;
        private readonly ICompanyService companyService;
        private readonly IUserService userService;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public ClientService(
            IDeletableEntityRepository<ApplicationUser> applicationUser,
            ICompanyService companyService,
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

        public async Task<Result> AddAsync(CreateClientInputModel model)
        {
            var emailExists = await this.userService.ExistsByFullNameByEmailAsync(model.FullName, model.Email);

            if (!emailExists)
            {
                var error = string.Format(ErrorMessageConstants.EmailExists, model.FullName, model.Email);

                return new ErrorModel(HttpStatusCode.BadRequest, error);
            }

            var user = await this.userService.GetByEmailIncludedRolesAndCompanyAsync(model.Email);

            var ownerExists = await this.companyService.ExistsOwnerAsync(user.Company.Name);

            if (ownerExists)
            {
                var error = string.Format(ErrorMessageConstants.OwnerExists, user.Company.Name);

                return new ErrorModel(HttpStatusCode.BadRequest, error);
            }

            if (user.Roles.Any())
            {
                var administratorRole = await this.roleManager.FindByNameAsync(AdministratorRoleName);

                if (user.Roles.Any(r => r.RoleId == administratorRole.Id))
                {
                    var error = ErrorMessageConstants.AdminDowngrade;

                    return new ErrorModel(HttpStatusCode.BadRequest, error);
                }

                var ownerRole = await this.roleManager.FindByNameAsync(CompanyOwnerRoleName);

                if (user.Roles.Any(r => r.RoleId == ownerRole.Id))
                {
                    var error = ErrorMessageConstants.AlreadyOwner;

                    return new ErrorModel(HttpStatusCode.BadRequest, error);
                }

                var employeeRole = await this.roleManager.FindByNameAsync(CompanyEmployeeRoleName);

                if (user.Roles.Any(r => r.RoleId == employeeRole.Id))
                {
                    await this.userManager.RemoveFromRoleAsync(user, CompanyEmployeeRoleName);
                }
            }

            await this.userManager.AddToRoleAsync(user, CompanyOwnerRoleName);

            var client = new ClientDetailsViewModel
            {
                Id = user.Id,
                Email = user.Email,
                NormalizedEmail = user.NormalizedEmail,
                CompanyName = user.Company?.Name,
            };

            return new ResultModel(client);
        }

        public async Task<Result> GetPortionAsync(int skip = default, int take = TakeDefaultValue)
        {
            var role = await this.roleManager.FindByNameAsync(CompanyOwnerRoleName);

            var clientsCount = await this.applicationUser
                .AllAsNoTracking()
                .Where(au => au.Roles.Any(r => r.RoleId == role.Id))
                .CountAsync();

            var isViewMoreAvaliable = (clientsCount - skip - take) > 0;

            var portions = await this.applicationUser
                 .AllAsNoTracking()
                 .Include(au => au.Company)
                 .OrderByDescending(au => au.CreatedOn)
                 .Where(au => au.Roles.Any(r => r.RoleId == role.Id))
                 .Skip(skip)
                 .Take(take)
                 .To<ClientDetailsViewModel>()
                 .ToListAsync();

            var clients = new ClientsDetailsViewModel
            {
                Portions = portions,
                ViewMoreAvaliable = isViewMoreAvaliable,
            };

            return new ResultModel(clients);
        }
    }
}
