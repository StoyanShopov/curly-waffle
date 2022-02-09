namespace SBC.Services.Data.Company.Contracts
{
    using System.Threading.Tasks;

    public interface ICompanyService
    {
        Task<bool> ExistsByNameAsync(string name);

        Task<int> NoTrackGetCompanyByNameAsync(string name);
    }
}
