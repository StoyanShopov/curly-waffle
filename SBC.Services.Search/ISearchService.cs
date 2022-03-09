namespace SBC.Services.Search
{
    using SBC.Common;
    using SBC.Data.Models;
    using SBC.Web.ViewModels.User;
    using System.Threading.Tasks;

    public interface ISearchService
    {
        Task<Result> Search(string index, string id);
        Task<Result> Create(RegisterInputModel coach);
    }
}
