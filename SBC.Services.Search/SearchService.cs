namespace SBC.Services.Search
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Nest;
    using SBC.Common;
    using SBC.Data.Models;
    using SBC.Web.ViewModels.User;

    public class SearchService : ISearchService
    {
        private readonly ElasticClient client;

        public SearchService(IConfiguration configuration)
        {
            var settings = new ConnectionSettings(
                //  new Uri(configuration.GetValue<string>("ElasticCloud:Endpoint"))
                )
                .DefaultMappingFor<Coach>(x => x.IndexName("coaches"));
            //          .DefaultIndex("kibana_sample_data_ecommerce")
            //          .BasicAuthentication(configuration.GetValue<string>("ElasticCloud:BasicAuthUser"),
            //              configuration.GetValue<string>("ElasticCloud:BasicAuthPassword"));
            this.client = new ElasticClient(settings);
        }

        public async Task<Common.Result> Create(RegisterInputModel value)
        {
            var response = await this.client.IndexAsync<RegisterInputModel>(value, x => x.Index("coach"));
            
            return new ResultModel(response.IsValid ? response.Id : response.OriginalException.Message);
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
