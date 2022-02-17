namespace SBC.Services.Data.Category.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        Task<IEnumerable<TModel>> GetAllAsync<TModel>();
    }
}
