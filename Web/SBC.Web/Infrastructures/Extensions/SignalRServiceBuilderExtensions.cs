namespace SBC.Web.Infrastructures.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    public static class SignalRServiceBuilderExtensions
    {
        public static IServiceCollection AddAzureSignalRCore(this IServiceCollection services)
        {
            services.AddSignalRCore().AddAzureSignalR("Endpoint=https://devtestdemo.service.signalr.net;AccessKey=blyKS7YA4/RSix0ZBxffvJJR1+zVvEgw2NAEPY9CR+Y=;Version=1.0;");

            return services;
        }
    }
}
