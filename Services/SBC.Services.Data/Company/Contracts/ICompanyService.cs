namespace SBC.Services.Data.Company.Contracts
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.Administration.Company;

    public interface ICompanyService
    {
        Task<Result> AddAsync(AddRequestModel model);

        Task<Result> GetCountAsync();

        Task<bool> ExistsByEmailAsync(string email);

        Task<bool> ExistsOwnerAsync(string name);

        Task<bool> ExistsByNameAsync(string name);

        Task<int> GetIdByNameAsync(string name);
    }
}
