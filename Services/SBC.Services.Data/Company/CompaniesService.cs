namespace SBC.Services.Data.Company
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Web.ViewModels.Administration.Company;

    using static SBC.Common.GlobalConstants.RolesNamesConstants;

    public class CompaniesService : ICompaniesService
    {
        private readonly IDeletableEntityRepository<Company> companiesRepository;
        private readonly RoleManager<ApplicationRole> roleManager;

        public CompaniesService(
            IDeletableEntityRepository<Company> companiesRepository,
            RoleManager<ApplicationRole> roleManager)
        {
            this.companiesRepository = companiesRepository;
            this.roleManager = roleManager;
        }

        public async Task<Result> AddAsync(CreateCompanyInputModel model)
        {
            var existsByName = await this.ExistsByNameAsync(model.Name);

            if (existsByName)
            {
                var error = string.Format(ErrorMessageConstants.ExistsByName, model.Name);

                return new ErrorModel(HttpStatusCode.BadRequest, error);
            }

            var existsByEmail = await this.ExistsByEmailAsync(model.Email);

            if (existsByEmail)
            {
                var error = string.Format(ErrorMessageConstants.ExistsByEmail, model.Email);

                return new ErrorModel(HttpStatusCode.BadRequest, error);
            }

            var company = new Company
            {
                Name = model.Name,
                Email = model.Email,
                LogoUrl = model.LogoUrl,
            };

            await this.companiesRepository.AddAsync(company);
            await this.companiesRepository.SaveChangesAsync();

            return true;
        }

        public async Task<Result> GetCountAsync()
            => new ResultModel(await this.companiesRepository.AllAsNoTracking().CountAsync());

        public async Task<bool> ExistsByEmailAsync(string email)
            => await this.companiesRepository
                .AllAsNoTracking()
                .AnyAsync(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

        public async Task<bool> ExistsOwnerAsync(string name)
        {
            var role = await this.roleManager.FindByNameAsync(CompanyOwnerRoleName);

            return await this.companiesRepository
                .AllAsNoTracking()
                .Include(c => c.Employees)
                    .ThenInclude(e => e.Roles)
                .Where(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                .AnyAsync(c =>
                    c.Employees.Any(e =>
                        e.Roles.Any(r => r.RoleId == role.Id)));
        }

        public async Task<bool> ExistsByNameAsync(string name)
            => await this.companiesRepository
                .AllAsNoTracking()
                .AnyAsync(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        public async Task<int> GetIdByNameAsync(string name)
            => await this.companiesRepository
                .AllAsNoTracking()
                .Where(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                .Select(c => c.Id)
                .FirstOrDefaultAsync();
    }
}
