namespace SBC.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using SBC.Data.Models;

    internal class CoachCategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var categoryCoachList = new List<CategoryCoach>()
            {
                new CategoryCoach
                {
                    CoachId = 1,
                    CategoryId = 1,
                },

                new CategoryCoach
                {
                    CoachId = 2,
                    CategoryId = 2,
                },

                new CategoryCoach
                {
                    CoachId = 3,
                    CategoryId = 3,
                },
            };

            foreach (CategoryCoach categoryCoach in categoryCoachList)
            {
                var dbCoach = await dbContext.LanguageCoaches.FirstOrDefaultAsync(x => x.CoachId == categoryCoach.CoachId);

                if (dbCoach == null)
                {
                    await dbContext.CategoryCoaches.AddAsync(categoryCoach);
                }
            }
        }
    }
}
