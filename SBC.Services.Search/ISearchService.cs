namespace SBC.Services.Search
{
    using SBC.Common;
    using SBC.Web.ViewModels.Search;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ISearchService
    {
        Task<Result> Search(string index, string field, string value,int size, string sort, CancellationToken cancellationToken);
        Task<Result> Create(string index, CourseSearchModel value, CancellationToken cancellationToken);
        Task<Result> CreateMany(string index, List<CourseSearchModel> courses, CancellationToken none);
    }
}
