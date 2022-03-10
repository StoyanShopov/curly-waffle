namespace SBC.Services.Search
{
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    using Nest;
    using SBC.Common;
    using SBC.Data.Models;
    using SBC.Web.ViewModels.Coaches;

    public class SearchService : ISearchService
    {
        private readonly IElasticClient client;

        public SearchService(IElasticClient elasticClient)
        {
            this.client = elasticClient;
        }

        public async Task<Common.Result> Create( CoachSearchModel value, CancellationToken cancellationToken)
        {
            var response = await this.client.IndexAsync<CoachSearchModel>(value, x => x.Index("coach"), cancellationToken);

            if (response.IsValid)
            {
                return new ResultModel(response.Id);
            }
                return new ErrorModel(HttpStatusCode.BadRequest, response.OriginalException.Message);
        }

        public async Task<Common.Result> Search(string index, string id)
        {
            ISearchResponse<Coach> searchResponse = await client.SearchAsync<Coach>(s => s
                  .Index(index)
                  .Query(q => q
                      .Match(m => m
                          .Field(f => f.Id)
                          .Query(id)
                      )

                  ));

            var response = await client.GetAsync<Coach>(new DocumentPath<Coach>(new Id(id)), x => x.Index(index));

            return new ResultModel(response?.Source);
        }
    }
}
