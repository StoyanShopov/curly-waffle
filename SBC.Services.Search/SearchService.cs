namespace SBC.Services.Search
{
    using System;
    using System.Threading.Tasks;
    using Nest;
    using SBC.Common;
    using SBC.Data.Models;

    public class SearchService : ISearchService
    {
        private readonly ElasticClient client;

        public SearchService()
        {
            //var settings = new ConnectionSettings(new Uri(configuration.GetValue<string>("ElasticCloud:Endpoint")))
            //          .DefaultIndex("kibana_sample_data_ecommerce")
            //          .BasicAuthentication(configuration.GetValue<string>("ElasticCloud:BasicAuthUser"),
            //              configuration.GetValue<string>("ElasticCloud:BasicAuthPassword"));
            this.client = new ElasticClient();
        }

        public async Task<Common.Result> Search(string searchText)
        {
            ISearchResponse<Coach> searchResponse =await client.SearchAsync<Coach>(s => s
                 .From(0)
                 .Size(10)
                 .Query(q => q
                     .Match(m => m
                         .Field(f => f.LastName)
                         .Query(searchText)
                     )
                 ));

            return new ResultModel(searchResponse);
        }
    }
}
