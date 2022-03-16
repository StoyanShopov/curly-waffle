namespace SBC.Services.Search
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    using Nest;
    using SBC.Common;
    using SBC.Web.ViewModels.Search;

    public class SearchService : ISearchService
    {
        private readonly IElasticClient client;

        public SearchService(IElasticClient elasticClient)
        {
            this.client = elasticClient;
        }

        public async Task<Common.Result> Create(string index, SearchModel value, CancellationToken cancellationToken)
        {
            var response = await this.client.IndexAsync<SearchModel>(value, x => x.Index(index), cancellationToken);

            if (response.IsValid)
            {
                return new ResultModel(new { response.Id, response.Index });
            }
            return new ErrorModel(HttpStatusCode.BadRequest, response.OriginalException.Message);
        }

        public async Task<Common.Result> Search(string index, string field, string value, int size, string sort, CancellationToken cancellationToken)
        {
            var request = new SearchRequest<SearchModel>(index)
            {
                From = 0,
                Size = size,


                //Query = new MatchAllQuery(),
                //{
                //    Field = field,
                //    Query = value,
                //},

                //Query = String.IsNullOrEmpty(field)
                //? new MatchQuery() { Field = field, Query = value }
                //: new MatchAllQuery(),


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
            var searchResponse = await client.SearchAsync<SearchModel>(request, cancellationToken);

            return new ResultModel(searchResponse.Documents);
        }
    }
}
