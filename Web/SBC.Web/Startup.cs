namespace SBC.Web
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using Azure.Storage.Blobs;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;

    using SBC.Data;
    using SBC.Data.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Data.Repositories;
    using SBC.Data.Seeding;
    using SBC.Services.Blob;
    using SBC.Services.Data;
    using SBC.Services.Data.Categories;
    using SBC.Services.Data.Admin;
    using SBC.Services.Data.Client;
    using SBC.Services.Data.Coaches;
    using SBC.Services.Data.Companies;
    using SBC.Services.Data.Languages;
    using SBC.Services.Data.Courses;
    using SBC.Services.Data.Lectures;
    using SBC.Services.Data.Resources;
    using SBC.Services.Data.User;
    using SBC.Services.Data.Admin;
    using SBC.Services.Data.BusinessOwner;
    using SBC.Services.Data.Clients;
    using SBC.Services.Data.Coaches;
    using SBC.Services.Data.Companies;
    using SBC.Services.Data.Courses;
    using SBC.Services.Data.Lectures;
    using SBC.Services.Data.Resources;
    using SBC.Services.Data.Users;
    using SBC.Services.Identity;
    using SBC.Services.Mapping;
    using SBC.Services.Messaging;
    using SBC.Web.ViewModels;
    using SBC.Services.Identity.Contracts;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

            services.AddControllers();

            // Authorization in Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "SBC API",
                        Version = "v1",
                    });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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

                c.CustomSchemaIds(cs => string.Join('.', cs.FullName.Split('.').TakeLast(2)));
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSingleton(this.configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            services.AddControllers()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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
            services.AddTransient<ILecturesService, LecturesService>();
            services.AddTransient<IResourcesService, ResourcesService>();
            services.AddTransient<IIdentitiesService, IdentitiesService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddSingleton(x => new BlobServiceClient(this.configuration["AzureBlobStorageConnectionString"]));
            services.AddSingleton<IBlobService, BlobService>();
            services.AddTransient<IClientsService, ClientsService>();
            services.AddTransient<IDasboardService, DashboardService>();
            services.AddTransient<ICoursesService, CoursesService>();
            services.AddTransient<ICoachesService, CoachesService>();
            services.AddTransient<ICompaniesService, CompaniesService>();
            services.AddTransient<ILanguagesService, LanguagesService>();
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IClientsService, ClientsService>();
            services.AddTransient<IDasboardService, DashboardService>();
            services.AddTransient<ICoursesService, CoursesService>();
            services.AddTransient<ICoachesService, CoachesService>();
            services.AddTransient<IBusinessOwnerDashboardService, BusinessOwnerDashboardService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = "docs";
                });
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                // app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseCookiePolicy();

            app.UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
