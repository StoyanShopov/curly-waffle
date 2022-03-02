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
            var coaches = await this.coachesRepository
                .AllAsNoTracking()
                .Include(x => x.ClientCompanies)
                .Include(x => x.Company)
                .Include(x => x.Languages)
                .Include(x => x.Categories)
                .ToListAsync();

            var filteredCoaches = new List<CoachCardViewModel>();

            foreach (var coach in coaches)
            {
                if (coach.ClientCompanies.Any(x => x.CompanyId == companyId))
                {
                    filteredCoaches.Add(new CoachCardViewModel
                    {
                        Id = coach.Id,
                        FullName = $"{coach.FirstName} {coach.LastName}",
                        Languages = coach.Languages,
                        Categories = coach.Categories,
                        PricePerSession = coach.PricePerSession,
                        CompanyLogoUrl = coach.CompanyId != null ? coach.Company.LogoUrl : "Null",
                        IsActive = true,
                    });
                }
                else
                {
                    filteredCoaches.Add(new CoachCardViewModel
                    {
                        Id = coach.Id,
                        FullName = $"{coach.FirstName} {coach.LastName}",
                        Languages = coach.Languages,
                        Categories = coach.Categories,
                        PricePerSession = coach.PricePerSession,
                        CompanyLogoUrl = coach.CompanyId != null ? coach.Company.LogoUrl : "Null",
                        IsActive = false,
                    });
                }
            }

            return new ResultModel(filteredCoaches);
        }
    }
}
