namespace SBC.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Data.Models;

    using static SBC.Common.GlobalConstants.CoursesConstants;

    internal class CoursesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var coursesList = new List<Course>()
            {
                new Course
                {
                    Title = ManagementTitle,
                    Description = ManagementDescription,
                    PricePerPerson = 50,
                    VideoUrl = ManagementVideoUrl,
                    CategoryId = 1,
                    LanguageId = 1,
                    CoachId = 1,
                    DeletedOn = null,
                    IsDeleted = false,
                    PictureUrl = ManagementPictureUrl,
                },
                new Course
                {
                    Title = LeadershipTitle,
                    Description = LeadershipDescription,
                    PricePerPerson = 80,
                    VideoUrl = LeadershipVideoUrl,
                    CategoryId = 2,
                    LanguageId = 2,
                    CoachId = 2,
                    DeletedOn = null,
                    IsDeleted = false,
                    PictureUrl = LeadershipPictureUrl,
                },
                new Course
                {
                    Title = DesignTitle,
                    Description = DesignDescription,
                    PricePerPerson = 90.5m,
                    VideoUrl = DesignVideoUrl,
                    CategoryId = 3,
                    LanguageId = 3,
                    CoachId = 3,
                    DeletedOn = null,
                    IsDeleted = false,
                    PictureUrl = DesignPictureUrl,
                },
            };

            foreach (Course course in coursesList)
            {
                var dbCourse = await dbContext.Courses.FirstOrDefaultAsync(x => x.Title == course.Title);

                if (dbCourse == null)
                {
                    await dbContext.Courses.AddAsync(course);
                }
            }
        }
    }
}
