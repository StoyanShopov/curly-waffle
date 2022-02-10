namespace SBC.Services.Data.Category.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Services.Data.Category.Models;

    public interface ICategoryService
    {
        Task<List<ListingCategoryModel>> GetAll();
    }
}
