namespace SBC.Services.Data.Company
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Company.Contracts;

    public class CompanyService : ICompanyService
    {
        private readonly IDeletableEntityRepository<Company> company;

        public CompanyService(IDeletableEntityRepository<Company> company)
        {
            this.company = company;
        }

        public async Task<bool> ExistsByNameAsync(string name)
            => await this.company
                .AllAsNoTracking()
                .AnyAsync(c => c.Name.ToLower() == name.ToLower());

        public async Task<Company> AllGetCompanyAsync(string name)
            => await this.company
                .All()
                .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
    }
}
