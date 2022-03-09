namespace SBC.Services.Data.Companies
{
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Mapping;
    using SBC.Web.ViewModels.Administration.Companies;
    using SBC.Web.ViewModels.Company;

    using static SBC.Common.ErrorMessageConstants.Company;
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

        public async Task<Result> GetAllAsync<TModel>()
             => new ResultModel(await this.companiesRepository
                .AllAsNoTracking()
                .To<CompanyViewModel>()
                .ToListAsync());

        public async Task<Result> GetEmailByIdAsync(int id)
        {
            var result = await this.companiesRepository.AllAsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            return new ResultModel(result);
        }

        public async Task<Result> AddAsync(CreateCompanyInputModel model)
        {
            var existsByName = await this.ExistsByNameAsync(model.Name);

            if (existsByName)
            {
                var error = string.Format(ExistsByName, model.Name);

                return new ErrorModel(HttpStatusCode.BadRequest, error);
            }

            var existsByEmail = await this.ExistsByEmailAsync(model.Email);

            if (existsByEmail)
            {
                var error = string.Format(ExistsByEmail, model.Email);

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

        public async Task<int> GetCountAsync()
            => await this.companiesRepository
                .AllAsNoTracking()
                .CountAsync();

        public async Task<bool> ExistsByEmailAsync(string email)
            => await this.companiesRepository
                .AllAsNoTracking()
                .AnyAsync(c => c.Email.ToLower() == email.ToLower());

        public async Task<bool> ExistsOwnerAsync(string name)
        {
            var role = await this.roleManager.FindByNameAsync(CompanyOwnerRoleName);

            return await this.companiesRepository
                .AllAsNoTracking()
                .Include(c => c.Employees)
                    .ThenInclude(e => e.Roles)
                .Where(c => c.Name.ToLower() == name.ToLower())
                .AnyAsync(c =>
                    c.Employees.Any(e =>
                        e.Roles.Any(r => r.RoleId == role.Id)));
        }

        public async Task<bool> ExistsByNameAsync(string name)
            => await this.companiesRepository
                .AllAsNoTracking()
                .AnyAsync(c => c.Name.ToLower() == name.ToLower());

        public async Task<int> GetIdByNameAsync(string name)
            => await this.companiesRepository
                .AllAsNoTracking()
                .Where(c => c.Name.ToLower() == name.ToLower())
                .Select(c => c.Id)
                .FirstOrDefaultAsync();
    }
}
