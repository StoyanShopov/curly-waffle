namespace SBC.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Data.Models;

    internal class CompanyCoursesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var companyCourseList = new List<CompanyCourse>()
            {
                new CompanyCourse
                {
                    CourseId = 1,
                    CompanyId = 2,
                    PurchaseDate = DateTime.Now,
                },

                new CompanyCourse
                {
                    CourseId = 2,
                    CompanyId = 2,
                    PurchaseDate = DateTime.Now,
                },

                new CompanyCourse
                {
                    CourseId = 3,
                    CompanyId = 2,
                    PurchaseDate = DateTime.Now,
                },
            };

            foreach (CompanyCourse companyCourse in companyCourseList)
            {
                var dbCompanyCourse = await dbContext.CompanyCourses
                    .FirstOrDefaultAsync(x => x.CourseId == companyCourse.CourseId && x.CompanyId == companyCourse.CompanyId);

                if (dbCompanyCourse == null)
                {
                    await dbContext.CompanyCourses.AddAsync(companyCourse);
                }
            }
        }
    }
}
