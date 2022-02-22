namespace SBC.Services.Data.Client.Contracts
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.Administration.Client;

    public interface IClientService
    {
        Task<Result> AddAsync(AddRequestModel model);

        Task<Result> GetPortionAsync(int skip, int take = 3);
    }
}
