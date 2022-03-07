namespace SBC.Services.Data.Category
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
             => await this.categoryRepository
                .AllAsNoTracking()
                .To<TModel>()
                .ToListAsync();
    }
}
