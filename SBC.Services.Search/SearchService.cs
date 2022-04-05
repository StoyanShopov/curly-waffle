namespace SBC.Services.Search
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    using Nest;
    using SBC.Common;
    using SBC.Web.ViewModels.Search;

    public class SearchService : ISearchService
    {
        private readonly IElasticClient elasticClient;

        public SearchService(IElasticClient elasticClient)
        {
            this.elasticClient = elasticClient;
        }

        public async Task<Common.Result> CreateAsync(
            string index,
            CourseSearchModel value,
            CancellationToken cancellationToken)
        {
            var response = await this.elasticClient.IndexAsync<CourseSearchModel>(value, x => x.Index(index), cancellationToken);

            if (response.IsValid)
            {
                return new ResultModel(new { response.Id, response.Index });
            }

            return new ErrorModel(HttpStatusCode.BadRequest, response.OriginalException.Message);
        }

        public async Task<Common.Result> CreateManyAsync(
            string index,
            List<CourseSearchModel> values,
            CancellationToken cancellationToken)
        {
            var response = await this.elasticClient.IndexManyAsync<CourseSearchModel>(values, index, cancellationToken);

            if (response.IsValid)
            {
                return new ResultModel(new { response.ServerError, response.Errors });
            }

            return new ErrorModel(HttpStatusCode.BadRequest, response.OriginalException.Message);
        }

        public async Task<Common.Result> SearchAsync(string index, string field, string value, int size, string sort, CancellationToken cancellationToken)
        {
            var request = new SearchRequest<CourseSearchModel>(index)
            {
                From = 0,
                Size = size,

                Query = new MatchQuery() { Field = field, Query = value },

                Sort = sort != null
                ? new List<ISort> { new FieldSort
                                            {
                                                Field = field,
                                                Order = sort.Equals("desc") ?SortOrder.Descending: SortOrder.Ascending
                                            },
                                   }
                : null
            };

            var searchResponse = await elasticClient.SearchAsync<CourseSearchModel>(request, cancellationToken);

            return new ResultModel(searchResponse.Documents);
        }
    }
}
