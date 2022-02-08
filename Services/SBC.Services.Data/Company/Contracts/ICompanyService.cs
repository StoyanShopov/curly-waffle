namespace SBC.Services.Data.Company.Contracts
{
    using System.Threading.Tasks;

    using SBC.Data.Models;

    public interface ICompanyService
    {
        Task<bool> ExistsByNameAsync(string name);

        Task<Company> AllGetCompanyAsync(string name);
    }
}
