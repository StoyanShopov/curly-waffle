namespace SBC.Services.Data.Coach
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;

    public class CoachesService : ICoachesService
    {
        private readonly IDeletableEntityRepository<Coach> coachRepository;

        public CoachesService(IDeletableEntityRepository<Coach> coachRepository)
            => this.coachRepository = coachRepository;

        public async Task<int> GetCountAsync()
            => await this.coachRepository
                .AllAsNoTracking()
                .CountAsync();
    }
}
