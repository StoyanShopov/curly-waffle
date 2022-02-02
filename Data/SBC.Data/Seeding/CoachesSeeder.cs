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
                    DeletedOn = null,
                    IsDeleted = false,
                },
                new Coach
                {
                   FirstName = CoachFirstNameMaria,
                   LastName = CoachLastNamePetrova,
                   Description = MariaDescription,
                   VideoUrl = MariaVideoUrl,
                   PricePerSession = 250,
                   CalendlyUrl = MariaCalendlyUrl,
                   DeletedOn = null,
                   IsDeleted = false,
                },
                new Coach
                {
                   FirstName = CoachFirstNameEmil,
                   LastName = CoachLastNameEmilov,
                   Description = EmilDescription,
                   VideoUrl = EmilVideoUrl,
                   PricePerSession = 130.30m,
                   CalendlyUrl = EmilCalendlyUrl,
                   DeletedOn = null,
                   IsDeleted = false,
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
