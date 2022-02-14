namespace SBC.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Data.Models;

    using static SBC.Common.GlobalConstants.LecturesConstants;

    internal class LecturesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var lecturesList = new List<Lecture>()
            {
                new Lecture
                {
                    Name = PlanningLectureName,
                    Description = PlanningLectureDescription,
                    DeletedOn = null,
                    IsDeleted = false,
                },
                new Lecture
                {
                    Name = BrandingLectureName,
                    Description = BrandingLectureDescription,
                    DeletedOn = null,
                    IsDeleted = false,
                },
                new Lecture
                {
                    Name = BusinessModelLectureName,
                    Description = BusinessModelLectureDescription,
                    DeletedOn = null,
                    IsDeleted = false,
                },
            };

            foreach (Lecture lecture in lecturesList)
            {
                var dbLecture = await dbContext.Lectures.FirstOrDefaultAsync(x => x.Name == lecture.Name);

                if (dbLecture == null)
                {
                    await dbContext.Lectures.AddAsync(lecture);
                }
            }
        }
    }
}
