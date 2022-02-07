namespace SBC.Services.Data.Client.Contracts
{
    using System.Threading.Tasks;

    using SBC.Common;

    public interface IClientService
    {
        Task<Result> AddAsync(string fullName, string email);

        Task<Result> GetPortionAsync(int skip, int take = 3);
    }
}
