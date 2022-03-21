namespace SBC.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Data.Models;

    using static SBC.Common.GlobalConstants.CoachConstants;

    internal class CoachesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var coachesList = new List<Coach>()
            {
                new Coach
                {
                    FirstName = CoachFirstNameIvan,
                    LastName = CoachLastNameIvanov,
                    Description = IvanDescription,
                    VideoUrl = IvanVideoUrl,
                    PricePerSession = 110,
                    CalendlyUrl = IvanCalendlyUrl,
                    CompanyId = 1,
                    DeletedOn = null,
                    IsDeleted = false,
                    ImageUrl = "https://upskillstoragetest.blob.core.windows.net/upskillcontainertest/ced7f6bb-5ada-4b69-b470-834e748326fe",
                },
                new Coach
                {
                   FirstName = CoachFirstNameMaria,
                   LastName = CoachLastNamePetrova,
                   Description = MariaDescription,
                   VideoUrl = MariaVideoUrl,
                   PricePerSession = 250,
                   CalendlyUrl = MariaCalendlyUrl,
                   CompanyId = 2,
                   DeletedOn = null,
                   IsDeleted = false,
                   ImageUrl = "https://upskillstoragetest.blob.core.windows.net/upskillcontainertest/c238e4e5-ab4e-4771-a6c8-be3f6e108a91",
                },
                new Coach
                {
                   FirstName = CoachFirstNameEmil,
                   LastName = CoachLastNameEmilov,
                   Description = EmilDescription,
                   VideoUrl = EmilVideoUrl,
                   PricePerSession = 130.30m,
                   CalendlyUrl = EmilCalendlyUrl,
                   CompanyId = 3,
                   DeletedOn = null,
                   IsDeleted = false,
                   ImageUrl = "https://upskillstoragetest.blob.core.windows.net/upskillcontainertest/aec644b0-4fe9-4b54-a114-20cc3a0d6bb7",
                },
            };

            foreach (Coach coach in coachesList)
            {
                var dbCoach = await dbContext.Coaches.FirstOrDefaultAsync(x => x.CalendlyUrl == coach.CalendlyUrl);

                if (dbCoach == null)
                {
                    await dbContext.Coaches.AddAsync(coach);
                }
            }
        }
    }
}
