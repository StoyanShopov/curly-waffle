namespace SBC.Services.Data.Client
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.Administration.Client;

    public interface IClientsService
    {
        Task<Result> AddAsync(CreateClientInputModel model);

        Task<Result> GetPortionAsync(int skip, int take = 3);
    }
}
