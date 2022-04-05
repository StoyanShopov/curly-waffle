namespace SBC.Services.Data.Clients
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.Administration.Client;

    using static SBC.Common.GlobalConstants.ClientConstants;

    public interface IClientsService
    {
        Task<Result> CreateAsync(CreateClientInputModel model);

        Task<Result> GetPortionAsync(int skip, int take = TakeDefaultValue);
    }
}
