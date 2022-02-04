namespace SBC.Services.Data.Company.Contracts
{
    using System.Threading.Tasks;

    using SBC.Common;

    public interface ICompanyService
    {
        public Task<Result> GetCount();
    }
}
