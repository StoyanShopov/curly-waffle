namespace SBC.Services.Data.Categories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoriesService(IDeletableEntityRepository<Category> data)
        {
            this.categoryRepository = data;
        }

        public async Task<Result> GetAllAsync<TModel>()
             => new ResultModel(await this.categoryRepository
                .AllAsNoTracking()
                .To<TModel>()
                .ToListAsync());

        public async Task<Result> GetByCoachIdAsync(int coachId)
            => new ResultModel(await this.categoryRepository
                .AllAsNoTracking()
                .Where(x => x.Id == coachId)
                .ToListAsync());
    }
}
