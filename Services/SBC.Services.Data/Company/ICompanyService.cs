namespace SBC.Services.Data.Company
{
    using System.Threading.Tasks;

    public interface ICompanyService
    {
        Task<bool> ExistsByNameAsync(string name);

        Task<int> NoTrackGetCompanyByNameAsync(string name);
    }
}
