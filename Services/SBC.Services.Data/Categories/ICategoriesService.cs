namespace SBC.Services.Data.Categories
{
    using System.Threading.Tasks;

    using SBC.Common;

    public interface ICategoriesService
    {
        Task<Result> GetAllAsync<TModel>();

        Task<Result> GetByCoachIdAsync(int coachId);
    }
}
