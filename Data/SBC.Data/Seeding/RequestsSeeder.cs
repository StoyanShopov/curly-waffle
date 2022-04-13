namespace SBC.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Data.Models;

    using static SBC.Common.SeederConstants.CompaniesNamesConstants;
    using static SBC.Common.SeederConstants.RequestsConstants;

    internal class RequestsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var requestsList = new List<Request>()
            {
                new Request
                {
                    Name = NameIvan,
                    CompanyName = MotionCompanyName,
                    Email = IvanEmail,
                    PhoneNumber = PhoneNumber1,
                    Date = DateTime.Now,
                    DeletedOn = null,
                    IsDeleted = false,
                },
                new Request
                {
                    Name = NameMaria,
                    CompanyName = SoftUniCompanyName,
                    Email = MariaEmail,
                    PhoneNumber = PhoneNumber2,
                    Date = DateTime.Now,
                    DeletedOn = null,
                    IsDeleted = false,
                },
                new Request
                {
                    Name = NameEmil,
                    CompanyName = SmartITCompanyName,
                    Email = EmilEmail,
                    PhoneNumber = PhoneNumber3,
                    Date = DateTime.Now,
                    DeletedOn = null,
                    IsDeleted = false,
                },
            };

            foreach (Request request in requestsList)
            {
                var dbRequest = await dbContext.Requests.FirstOrDefaultAsync(x => x.Email == request.Email);

                if (dbRequest == null)
                {
                    await dbContext.Requests.AddAsync(request);
                }
            }
        }
    }
}
