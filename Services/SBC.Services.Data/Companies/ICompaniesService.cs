namespace SBC.Services.Data.Companies
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.Administration.Companies;

    public interface ICompaniesService
    {
        Task<Result> AddAsync(CreateCompanyInputModel model);

        Task<Result> GetAllEmployeesAsync(int companyId);

        Task<Result> GetEmailByIdAsync(int id);

        Task<Result> GetAllAsync<TModel>();

        Task<int> GetCountAsync();

        Task<bool> ExistsByEmailAsync(string email);

        Task<bool> ExistsOwnerAsync(string name);

        Task<bool> ExistsByNameAsync(string name);

        Task<int> GetIdByNameAsync(string name);
    }
}
