namespace SBC.Web
{
    using System.Reflection;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using SBC.Services.Mapping;
    using SBC.Web.Infrastructures.Extensions;
    using SBC.Web.Infrastructures.Hub;
    using SBC.Web.ViewModels;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddDataBase(this.configuration)
                .AddIdentity()
                .AddApplicationConfigurations()
                .AddSwagger()
                .AddSpaFiles()
                .AddDatabaseDeveloperPageExceptionFilter()
                .AddSingleton(this.configuration)
                .AddAzureSignalR()
                .AddDataRepositories()
                .AddJwtAuthentication(services.GetAppSettings(this.configuration))
                .AddApplicationServices(this.configuration)
                .AddAppInsightsTelemetry()
                .AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            if (env.IsDevelopment())
            {
                app
                    .UseDeveloperExceptionPage()
                    .UseMigrationsEndPoint();
            }
            else
            {
                // app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app
                .PrepareDataBase()
                .ApplySwagger()
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseCookiePolicy()
                .UseCors(options => options
                   .AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod())
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseAzureSignalR(builder =>
                {
                    builder.MapHub<NotificationHub>("/Notification");
                })
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapDefaultControllerRoute();
                })
                .UseSpaStaticFiles();

            app.ApplySpa(env);
        }
    }
}
