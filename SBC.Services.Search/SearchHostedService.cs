using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SBC.Services.Search
{
    public class SearchHostedService : BackgroundService
    {
        protected IServiceProvider _serviceProvider;
        protected ISearchService _searchService;

        public SearchHostedService([NotNull] IServiceProvider serviceProvider,
            [NotNull] ISearchService searchService)
        {
            _serviceProvider = serviceProvider;
            _searchService = searchService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var hostedServiceDbContext = (ISearchSeedersService)scope.ServiceProvider.GetRequiredService(typeof(ISearchSeedersService));
                    await hostedServiceDbContext.SeedCoursesAsync();
                }

                int hoursDelay = 365 * 24;
                await Task.Delay(new TimeSpan(hoursDelay, 0, 0));
            }

        }
    }
}
