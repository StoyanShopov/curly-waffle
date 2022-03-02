namespace SBC.Services.Data.Company
{
    using SBC.Common;
    using System.Threading.Tasks;

    public interface ICompaniesService
    {
        Task<Result> GetEmailByIdAsync(int id);

        Task<bool> ExistsByNameAsync(string name);

        Task<int> NoTrackGetCompanyByNameAsync(string name);
    }
}
