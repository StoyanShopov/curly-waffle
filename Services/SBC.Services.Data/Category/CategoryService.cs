namespace SBC.Services.Data.Category
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Category.Contracts;
    using SBC.Services.Data.Category.Models;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoryService(IDeletableEntityRepository<Category> data)
        {
            this.categoryRepository = data;
        }

        public Task<List<ListingCategoryModel>> GetAll()
            => Task.FromResult(this.categoryRepository.AllAsNoTracking().Select(x => new ListingCategoryModel { Name = x.Name }).ToList());
    }
}
