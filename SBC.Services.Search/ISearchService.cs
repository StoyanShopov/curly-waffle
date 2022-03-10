namespace SBC.Services.Search
{
    using SBC.Common;
    using SBC.Web.ViewModels.Coaches;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ISearchService
    {
        Task<Result> Search(string index, string id);
        Task<Result> Create(CoachSearchModel value, CancellationToken cancellationToken);
    }
}
