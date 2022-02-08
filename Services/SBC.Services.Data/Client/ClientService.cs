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
    using SBC.Services.Data.User.Contracts;

    using static SBC.Common.GlobalConstants.RolesNamesConstants;

    public class ClientService : IClientService
    {
        private const int TakeDefaultValue = 3;

        private readonly IDeletableEntityRepository<ApplicationUser> applicationUser;
        private readonly IUserService userService;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public ClientService(
            IDeletableEntityRepository<ApplicationUser> applicationUser,
            IUserService userService,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            this.applicationUser = applicationUser;
            this.roleManager = roleManager;
            this.userService = userService;
            this.userManager = userManager;
        }

        // TODO: fullName not implemented in logic
        public async Task<Result> AddAsync(string fullName, string email)
        {
            //var emailExists = await this.userService.NoTrackUserExistsByEmailByFullNameAsync(email);
            var emailExists = await this.userService.NoTrackUserExistsByEmailAsync(email);

            if (!emailExists)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, $"There is no user with the given '{email}'.");
                //return new ErrorModel(HttpStatusCode.BadRequest, $"There is no user with the given '{fullName}' and '{email}'.");
            }

            var user = await this.userService.AllGetByEmailAndRolesAsync(email);

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

            return true;
        }

        public async Task<Result> GetPortionAsync(int skip = 0, int take = TakeDefaultValue)
        {
            var role = await this.roleManager.FindByNameAsync(CompanyOwnerRoleName);

            var portions = await this.applicationUser
                 .AllAsNoTracking()
                 .OrderByDescending(au => au.CreatedOn)
                 .Where(au => au.Roles.Any(r => r.RoleId == role.Id))
                 .Skip(skip)
                 .Take(take)
                 .Include(au => au.Company)
                 .Select(au => new GetPortionServiceModel
                 {
                     Email = au.Email,
                     NormalizedEmail = au.NormalizedEmail,
                     CompanyName = au.Company.Name,
                 })
                 .ToListAsync();

            return new ResultModel(new GetPortionsServiceModel { Portions = portions });
        }
    }
}
