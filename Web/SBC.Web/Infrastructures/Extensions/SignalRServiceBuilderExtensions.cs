namespace SBC.Web.Infrastructures.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    public static class SignalRServiceBuilderExtensions
    {
        public static IServiceCollection AddAzureSignalR(this IServiceCollection services)
        {
            services.AddSignalR().AddAzureSignalR("Endpoint=https://upskills.service.signalr.net;AccessKey=KinRlZlFDxiTRSjAowsvIWHpORS+Qmw/LmvQRnbzQJQ=;Version=1.0;");

            return services;
        }
    }
}
