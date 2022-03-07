namespace SBC.Services.Data.Company
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class CompaniesService : ICompaniesService
    {
        private readonly IDeletableEntityRepository<Company> companiesRepository;

        public CompaniesService(IDeletableEntityRepository<Company> company)
        {
            this.companiesRepository = company;
        }

        public async Task<Result> GetEmailByIdAsync(int id)
        {
            var result = await this.companiesRepository.AllAsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            return new ResultModel(result.Email);
        }

        public async Task<bool> ExistsByNameAsync(string name)
            => await this.companiesRepository
                .AllAsNoTracking()
                .AnyAsync(c => c.Name.ToLower() == name.ToLower());

        public async Task<int> NoTrackGetCompanyByNameAsync(string name)
            => await this.companiesRepository
                .AllAsNoTracking()
                .Where(c => c.Name.ToLower() == name.ToLower())
                .Select(c => c.Id)
                .FirstOrDefaultAsync();

        public async Task<Result> GetAllAsync<TModel>()
             => new ResultModel(await this.companiesRepository
                .AllAsNoTracking()
                .To<TModel>()
                .ToListAsync());
    }
}
