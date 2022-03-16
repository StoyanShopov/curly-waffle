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
    using SBC.Services.Messaging;
    using SBC.Services.Search;
    using SBC.Web.ViewModels;
    using SBC.Web.ViewModels.Search;

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
                .AddDataRepositories()
                .AddJwtAuthentication(services.GetAppSettings(this.configuration))
                .AddApplicationServices(this.configuration)
                .AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        // Data repositories
        services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Jwt
            var appSettingsSectionConfiguration = this.configuration.GetSection("AppSettings");
        services.Configure<AppSettings>(appSettingsSectionConfiguration);

            var appSettings = appSettingsSectionConfiguration.Get<AppSettings>();
        var key = Encoding.ASCII.GetBytes(appSettings.Secret);

        services
            .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

            // Application services
            services.AddTransient<ICompaniesService, CompaniesService>();
            services.AddTransient<IEmailSender>(x => new SendGridEmailSender(this.configuration["SendGridAPIKey"]));
            services.AddTransient<IIdentitiesService, IdentitiesService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddSingleton(x => new BlobServiceClient(this.configuration["AzureBlobStorageConnectionString"]));
            services.AddSingleton<IBlobService, BlobService>();
            services.AddTransient<IClientsService, ClientsService>();
            services.AddTransient<IDasboardService, DashboardService>();
            services.AddTransient<ICoursesService, CoursesService>();
            services.AddTransient<ICompaniesService, CompaniesService>();
            services.AddTransient<ICoachesService, CoachesService>();
         //var elasticSetting = new ConnectionSettings(new StaticConnectionPool(new Uri[] { new Uri("https://localhost:9200/") }))
            //                        .DisableDirectStreaming()
            //                        .PrettyJson();
            //services.AddSingleton<IElasticClient>(new ElasticClient(elasticSetting));            
            //var elasticSetting = new ConnectionSettings(new StaticConnectionPool(new Uri[] { new Uri("https://localhost:9200/") }))
            //                        .DisableDirectStreaming()
            //                        .PrettyJson();

            services.AddSingleton<IElasticClient>(sp =>
            {
                var config = sp.GetRequiredService<IConfiguration>();

    var settings = new ConnectionSettings(
        config["cloudId"],
        new BasicAuthenticationCredentials("elastic", config["password"]));
                //.DefaultIndex("coach")
                //.DefaultMappingFor<SearchModel>(i => i
                //.IndexName("coach"));

                return new ElasticClient(settings);
});

services.AddTransient<ISearchService, SearchService>();
        
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

    if (env.IsDevelopment())
    {
        app
            .ApplySwagger()
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
        .UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
        })
        .ApplySpa(env)
        .UseSpaStaticFiles();
}
    }
}
