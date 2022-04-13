namespace SBC.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Data.Models;

    using static SBC.Common.SeederConstants.LecturesConstants;

    internal class CourseLecturesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var courseLectureList = new List<CourseLecture>()
            {
                new CourseLecture
                {
                    CourseId = 1,
                    Lecture = dbContext.Lectures.Where(x => x.Name == PlanningLectureName).FirstOrDefault(),
                },

                new CourseLecture
                {
                    CourseId = 2,
                    Lecture = dbContext.Lectures.Where(x => x.Name == BrandingLectureName).FirstOrDefault(),
                },

                new CourseLecture
                {
                    CourseId = 3,
                    Lecture = dbContext.Lectures.Where(x => x.Name == BusinessModelLectureName).FirstOrDefault(),
                },
            };

            foreach (CourseLecture courseLecture in courseLectureList)
            {
                var dbCourseLecture = await dbContext.CourseLectures
                    .FirstOrDefaultAsync(x => x.CourseId == courseLecture.CourseId && x.Lecture == courseLecture.Lecture);

                if (dbCourseLecture == null)
                {
                    await dbContext.CourseLectures.AddAsync(courseLecture);
                }
            }
        }
    }
}
