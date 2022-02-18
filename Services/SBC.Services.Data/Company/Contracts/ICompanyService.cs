namespace SBC.Services.Data.Company.Contracts
{
    using System.Threading.Tasks;

    using SBC.Common;

    public interface ICompanyService
    {
        Task<Result> GetCountAsync();

        Task<bool> ExistsOwner(string name);

        Task<bool> ExistsByNameAsync(string name);

        Task<int> GetIdByNameAsync(string name);
    }
}
