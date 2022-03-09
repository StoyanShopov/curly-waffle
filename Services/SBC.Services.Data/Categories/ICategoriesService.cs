namespace SBC.Services.Data.Categories
{
    using SBC.Common;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        Task<Result> GetAllAsync<TModel>();
    }
}
