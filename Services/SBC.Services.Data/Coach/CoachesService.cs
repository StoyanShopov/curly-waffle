namespace SBC.Services.Data.Coach
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Coach;

    public class CoachesService : ICoachesService
    {
        private readonly IDeletableEntityRepository<Coach> coachRepository;

        public CoachesService(IDeletableEntityRepository<Coach> coachRepository) => this.coachRepository = coachRepository;

        public async Task<Result> GetCountAsync() => new ResultModel(await this.coachRepository.AllAsNoTracking().CountAsync());
    }
}
