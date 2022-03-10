namespace SBC.Services.Data.Coaches
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Web.ViewModels.Coaches;

    public class CoachesService : ICoachesService
    {
        private readonly IDeletableEntityRepository<Coach> coachesRepository;

        public CoachesService(IDeletableEntityRepository<Coach> coachesRepository)
        {
            this.coachesRepository = coachesRepository;
        }

        public async Task<Result> GetAllWithActive(int companyId)
        {
            var filteredCoaches = await this.coachesRepository
                .AllAsNoTracking()
                .Select(coach => new CoachCardViewModel
                {
                    Id = coach.Id,
                    FullName = $"{coach.FirstName} {coach.LastName}",
                    CategoryByDefault = coach.Categories.Count == 0 ? "Common" : coach.Categories.FirstOrDefault().Category.Name,
                    PricePerSession = coach.PricePerSession,
                    CompanyLogoUrl = coach.CompanyId != null ? coach.Company.LogoUrl : "Null",
                    IsActive = coach.ClientCompanies.Any(x => x.CompanyId == companyId),
                })
                .ToListAsync();

            return new ResultModel(filteredCoaches);
        }

        public async Task<int> GetCountAsync()
            => await this.coachesRepository
                .AllAsNoTracking()
                .CountAsync();
    }
}
