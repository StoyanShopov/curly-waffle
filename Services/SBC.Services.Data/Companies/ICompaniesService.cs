namespace SBC.Services.Data.Company
{
    using System.Threading.Tasks;

    using SBC.Common;

    public interface ICompaniesService
    {
        Task<Result> GetEmailByIdAsync(int id);

        Task<Result> GetAllAsync<TModel>();

        Task<bool> ExistsByNameAsync(string name);

        Task<int> NoTrackGetCompanyByNameAsync(string name);
    }
}
