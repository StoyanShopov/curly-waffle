namespace SBC.Services.Data.Clients
{
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Companies;
    using SBC.Services.Data.Users;
    using SBC.Services.Mapping;
    using SBC.Web.ViewModels.Administration.Client;

    using static SBC.Common.ErrorConstants.Client;
    using static SBC.Common.GlobalConstants.RolesNamesConstants;

    public class ClientsService : IClientsService
    {
        private const int TakeDefaultValue = 3;

        private readonly IDeletableEntityRepository<ApplicationUser> applicationUsers;
        private readonly ICompaniesService companiesService;
        private readonly IUsersService usersService;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public ClientsService(
            IDeletableEntityRepository<ApplicationUser> applicationUser,
            ICompaniesService companyService,
            IUsersService userService,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            this.applicationUsers = applicationUser;
            this.companiesService = companyService;
            this.usersService = userService;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<Result> AddAsync(CreateClientInputModel model)
        {
            var emailExists = await this.usersService.ExistsByFullNameByEmailAsync(model.FullName, model.Email);

            if (!emailExists)
            {
                var error = string.Format(EmailExists, model.FullName, model.Email);

                return new ErrorModel(HttpStatusCode.BadRequest, error);
            }

            var user = await this.applicationUsers
                .All()
                .Include(au => au.Roles)
                .Include(au => au.Company)
                .FirstOrDefaultAsync(u => u.NormalizedEmail == model.Email.ToUpper());

            var ownerExists = await this.companiesService.ExistsOwnerAsync(user.Company.Name);

            if (ownerExists)
            {
                var error = string.Format(OwnerExists, user.Company.Name);

                return new ErrorModel(HttpStatusCode.BadRequest, error);
            }

            if (user.Roles.Any())
            {
                var administratorRole = await this.roleManager.FindByNameAsync(AdministratorRoleName);

                if (user.Roles.Any(r => r.RoleId == administratorRole.Id))
                {
                    return new ErrorModel(HttpStatusCode.BadRequest, AdminDowngrade);
                }

                var ownerRole = await this.roleManager.FindByNameAsync(CompanyOwnerRoleName);

                if (user.Roles.Any(r => r.RoleId == ownerRole.Id))
                {
                    return new ErrorModel(HttpStatusCode.BadRequest, AlreadyOwner);
                }

                var employeeRole = await this.roleManager.FindByNameAsync(CompanyEmployeeRoleName);

                if (user.Roles.Any(r => r.RoleId == employeeRole.Id))
                {
                    await this.userManager.RemoveFromRoleAsync(user, CompanyEmployeeRoleName);
                }
            }

            await this.userManager.AddToRoleAsync(user, CompanyOwnerRoleName);

            var client = AutoMapperConfig.MapperInstance.Map<ClientDetailsViewModel>(user);

            return new ResultModel(client);
        }

        public async Task<Result> GetPortionAsync(int skip = default, int take = TakeDefaultValue)
        {
            var role = await this.roleManager.FindByNameAsync(CompanyOwnerRoleName);

            var clientsCount = await this.applicationUsers
                .AllAsNoTracking()
                .Where(au => au.Roles.Any(r => r.RoleId == role.Id))
                .CountAsync();

            var isViewMoreAvaliable = (clientsCount - skip - take) > 0;

            var portions = await this.applicationUsers
                 .AllAsNoTracking()
                 .Where(au => au.Roles.Any(r => r.RoleId == role.Id))
                 .OrderByDescending(au => au.CreatedOn)
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
