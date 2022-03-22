namespace SBC.Web.Infrastructures.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Azure.Storage.Blobs;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using SBC.Data;
    using SBC.Data.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Data.Repositories;
    using SBC.Services.Blob;
    using SBC.Services.Data.Admin;
    using SBC.Services.Data.Categories;
    using SBC.Services.Data.Client;
    using SBC.Services.Data.Coaches;
    using SBC.Services.Data.Companies;
    using SBC.Services.Data.Courses;
    using SBC.Services.Data.Languages;
    using SBC.Services.Data.Lectures;
    using SBC.Services.Data.Notifications;
    using SBC.Services.Data.Resources;
    using SBC.Services.Data.User;
    using SBC.Services.Identity;
    using SBC.Services.Identity.Contracts;
    using SBC.Services.Messaging;
    using SBC.Web.ViewModels.User;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationConfigurations(this IServiceCollection services)
            => services
                .Configure<CookiePolicyOptions>(options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddSingleton(x => new BlobServiceClient(configuration["AzureBlobStorageConnectionString"]))
                .AddSingleton<IBlobService, BlobService>()
                .AddSingleton<IDictionary<string, UserConnection>>(opts => new Dictionary<string, UserConnection>())
                .AddTransient<ICategoriesService, CategoriesService>()
                .AddTransient<IClientsService, ClientsService>()
                .AddTransient<ICoachesService, CoachesService>()
                .AddTransient<ICompaniesService, CompaniesService>()
                .AddTransient<ICoursesService, CoursesService>()
                .AddTransient<IDasboardService, DashboardService>()
                .AddTransient<IEmailSender>(x => new SendGridEmailSender(configuration["SendGridAPIKey"]))
                .AddTransient<IIdentitiesService, IdentitiesService>()
                .AddTransient<ILanguagesService, LanguagesService>()
                .AddTransient<ILecturesService, LecturesService>()
                .AddTransient<INotificationsService, NotificationsService>()
                .AddTransient<IResourcesService, ResourcesService>()
                .AddTransient<IUsersService, UsersService>();

        public static AppSettings GetAppSettings(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var appSettingsSectionConfiguration = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSectionConfiguration);

            return appSettingsSectionConfiguration.Get<AppSettings>();
        }

        public static IServiceCollection AddDataBase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<ApplicationDbContext>(options => options
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        public static IServiceCollection AddDataRepositories(this IServiceCollection services)
            => services
                .AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>))
                .AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
                .AddScoped<IDbQueryRunner, DbQueryRunner>();

        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            AppSettings appSettings)
        {
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

            return services;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                .AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }

        public static IServiceCollection AddSpaFiles(this IServiceCollection services)
        {
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
            => services
                .AddSwaggerGen(configure =>
                {
                    configure.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "SBC API",
                        Version = "v1",
                    });

                    configure.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    });

                    configure.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer",
                                },
                            },
                            Array.Empty<string>()
                        },
                    });

                    configure.CustomSchemaIds(cs => string.Join('.', cs.FullName.Split('.').TakeLast(2)));
                });
    }
}
