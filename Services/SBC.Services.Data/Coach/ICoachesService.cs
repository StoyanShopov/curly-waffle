namespace SBC.Services.Data.Coach
{
    using System.Threading.Tasks;

    public interface ICoachesService
    {
        Task<int> GetCountAsync();
    }
}
