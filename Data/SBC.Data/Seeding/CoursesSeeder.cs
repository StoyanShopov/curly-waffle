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
                    PictureUrl = "https://upskillstoragetest.blob.core.windows.net/upskillcontainertest/9f4e95f9-3f91-4f9e-b22b-e5cb09537360",
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
                    PictureUrl = "https://upskillstoragetest.blob.core.windows.net/upskillcontainertest/b0a4e660-36b8-4252-b24d-3b20ef3e8ba8",
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
                    PictureUrl = "https://upskillstoragetest.blob.core.windows.net/upskillcontainertest/11033e92-a2e6-46d8-a2e4-d3e82bfc50e8",
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
