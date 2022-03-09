namespace SBC.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using SBC.Data.Models;

    internal class LanguageCoachSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var languageCoachList = new List<LanguageCoach>()
            {
                new LanguageCoach
                {
                    CoachId = 1,
                    LanguageId = 1,
                },

                new LanguageCoach
                {
                    CoachId = 2,
                    LanguageId = 2,
                },

                new LanguageCoach
                {
                    CoachId = 3,
                    LanguageId = 3,
                },
            };

            foreach (LanguageCoach languageCoach in languageCoachList)
            {
                var dbCoach = await dbContext.LanguageCoaches.FirstOrDefaultAsync(x => x.CoachId == languageCoach.CoachId);

                if (dbCoach == null)
                {
                    await dbContext.LanguageCoaches.AddAsync(languageCoach);
                }
            }
        }
    }
}
