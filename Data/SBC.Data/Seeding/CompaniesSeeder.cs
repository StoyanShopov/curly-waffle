namespace SBC.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Data.Models;

    using static SBC.Common.GlobalConstants.CompaniesNamesConstants;
    using static SBC.Common.GlobalConstants.EmailsConstants;
    using static SBC.Common.GlobalConstants.LogoUrlConstants;

    internal class CompaniesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var companiesList = new List<Company>()
            {
                new Company
                {
                    Name = MotionCompanyName,
                    Email = MotionCompanyEmail,
                    LogoUrl = MotionCompanyUrl,
                    DeletedOn = null,
                    IsDeleted = false,
                },
                new Company
                {
                    Name = SoftUniCompanyName,
                    Email = SoftUniEmail,
                    LogoUrl = SoftUniUrl,
                    DeletedOn = null,
                    IsDeleted = false,
                },
            };

            foreach (Company company in companiesList)
            {
                var dbCompany = await dbContext.Companies.FirstOrDefaultAsync(x => x.Name == company.Name);

                if (dbCompany == null)
                {
                    await dbContext.Companies.AddAsync(company);
                }
            }
        }
    }
}
