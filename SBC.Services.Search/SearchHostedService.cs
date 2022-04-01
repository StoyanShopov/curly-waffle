namespace SBC.Services.Search
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class SearchHostedService : BackgroundService
    {
        protected IServiceProvider serviceProvider;
        protected ISearchService searchService;

        public SearchHostedService([NotNull] IServiceProvider serviceProvider,
            [NotNull] ISearchService searchService)
        {
            this.serviceProvider = serviceProvider;
            this.searchService = searchService;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                using (var scope = this.serviceProvider.CreateScope())
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
