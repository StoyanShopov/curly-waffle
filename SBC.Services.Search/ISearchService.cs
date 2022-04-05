namespace SBC.Services.Search
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
   
    using SBC.Common;
    using SBC.Web.ViewModels.Search;

    public interface ISearchService
    {
        Task<Result> CreateAsync(string index, CourseSearchModel value, CancellationToken cancellationToken);
        Task<Result> CreateManyAsync(string index, List<CourseSearchModel> courses, CancellationToken none);
        Task<Result> SearchAsync(string index, string field, string value, int size, string sort, CancellationToken cancellationToken);
    }
}
