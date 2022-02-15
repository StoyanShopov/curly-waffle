namespace SBC.Services.Data.Company.Contracts
{
    using System.Threading.Tasks;

    using SBC.Common;

    public interface ICompanyService
    {
        Task<bool> ExistsByNameAsync(string name);

        Task<int> NoTrackGetCompanyByNameAsync(string name);
        public Task<Result> GetCount();
    }
}
