namespace SBC.Services.Data.Company
{
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

    public class CompanyService : ICompanyService
    {
        private readonly IDeletableEntityRepository<Company> companyRepository;
        private readonly RoleManager<ApplicationRole> roleManager;

        public CompanyService(
            IDeletableEntityRepository<Company> companyRepository,
            RoleManager<ApplicationRole> roleManager)
        {
            this.companyRepository = companyRepository;
            this.roleManager = roleManager;
        }

        public async Task<Result> AddAsync(CreateCompanyInputModel model)
        {
            var existsByName = await this.ExistsByNameAsync(model.Name);

            if (existsByName)
            {
                var error = $"The company's name '{model.Name}' already exists.";

                return new ErrorModel(HttpStatusCode.BadRequest, error);
            }

            var existsByEmail = await this.ExistsByEmailAsync(model.Email);

            if (existsByEmail)
            {
                var error = $"The company's email '{model.Name}' already exists.";

                return new ErrorModel(HttpStatusCode.BadRequest, error);
            }

            var company = new Company
            {
                Name = model.Name,
                Email = model.Email,
                LogoUrl = model.LogoUrl,
            };

            await this.companyRepository.AddAsync(company);
            await this.companyRepository.SaveChangesAsync();

            return true;
        }

        public async Task<Result> GetCountAsync()
            => new ResultModel(await this.companyRepository.AllAsNoTracking().CountAsync());

        public async Task<bool> ExistsByEmailAsync(string email)
            => await this.NoTrackGetQuery()
                .AnyAsync(c => c.Email.ToLower() == email.ToLower());

        public async Task<bool> ExistsOwnerAsync(string name)
        {
            var role = await this.roleManager.FindByNameAsync(CompanyOwnerRoleName);

            return await this.NoTrackGetQueryByName(name)
                .Include(c => c.Employees)
                    .ThenInclude(e => e.Roles)
                .AnyAsync(c =>
                    c.Employees.Any(e =>
                        e.Roles.Any(r => r.RoleId == role.Id)));
        }

        public async Task<bool> ExistsByNameAsync(string name)
            => await this.NoTrackGetQueryByName(name)
                .AnyAsync(c => c.Name.ToLower() == name.ToLower());

        public async Task<int> GetIdByNameAsync(string name)
            => await this.NoTrackGetQueryByName(name)
                .Select(c => c.Id)
                .FirstOrDefaultAsync();

        private IQueryable<Company> NoTrackGetQueryByName(string name)
            => this.NoTrackGetQuery()
                .Where(c => c.Name.ToLower() == name.ToLower());

        private IQueryable<Company> NoTrackGetQuery()
            => this.companyRepository
                .AllAsNoTracking();
    }
}
