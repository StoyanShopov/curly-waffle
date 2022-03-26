namespace SBC.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Data.Models;

    internal class CompanyCoachesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var companyCoachList = new List<CompanyCoach>()
            {
                new CompanyCoach
                {
                    CoachId = 1,
                    CompanyId = 2,
                    HireDate = DateTime.Now,
                },

                new CompanyCoach
                {
                    CoachId = 2,
                    CompanyId = 2,
                    HireDate = DateTime.Now,
                },

                new CompanyCoach
                {
                    CoachId = 3,
                    CompanyId = 2,
                    HireDate = DateTime.Now,
                },
            };

            foreach (CompanyCoach companyCoach in companyCoachList)
            {
                var dbCompanyCoach = await dbContext.CompanyCoaches
                    .FirstOrDefaultAsync(x => x.CoachId == companyCoach.CoachId && x.CompanyId == companyCoach.CompanyId);

                if (dbCompanyCoach == null)
                {
                    await dbContext.CompanyCoaches.AddAsync(companyCoach);
                }
            }
        }
    }
}
