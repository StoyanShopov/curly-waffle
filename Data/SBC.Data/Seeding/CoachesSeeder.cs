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
                    ImageUrl = IvanImageUrl,
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
                   ImageUrl = MariaImageUrl,
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
                   ImageUrl = EmilImageUrl,
                },
            };

            foreach (Coach coach in coachesList)
            {
                var dbCoach = await dbContext.Coaches.FirstOrDefaultAsync(x => x.FirstName == coach.FirstName && x.LastName == coach.LastName);

                if (dbCoach == null)
                {
                    await dbContext.Coaches.AddAsync(coach);
                }
            }
        }
    }
}
