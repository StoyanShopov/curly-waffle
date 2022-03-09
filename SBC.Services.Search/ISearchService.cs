namespace SBC.Services.Search
{
    using SBC.Common;
    using System.Threading.Tasks;

    public interface ISearchService
    {
        Task<Result> Search (string searchText);
    }
}
