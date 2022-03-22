namespace SBC.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Data.Models;

    using static SBC.Common.GlobalConstants.LecturesConstants;
    using static SBC.Common.GlobalConstants.ResourcesConstants;

    internal class ResourcesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var resourcesList = new List<Resource>()
            {
                new Resource
                {
                    Name = IntroductionVideoResourceName,
                    FileUrl = IntroductionVideoFileUrl,
                    Size = 100,
                    FileType = FileType.Video,
                    DeletedOn = null,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Lecture = dbContext.Lectures.Where(x => x.Name == PlanningLectureName).FirstOrDefault(),
                },
                new Resource
                {
                    Name = MarketingVideoResourceName,
                    FileUrl = MarketingVideoFileUrl,
                    Size = 200,
                    FileType = FileType.Video,
                    DeletedOn = null,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Lecture = dbContext.Lectures.Where(x => x.Name == BrandingLectureName).FirstOrDefault(),
                },
                new Resource
                {
                    Name = DigitalMarketImageResourceName,
                    FileUrl = DigitalMarketImageFileUrl,
                    Size = 120,
                    FileType = FileType.Image,
                    DeletedOn = null,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Lecture = dbContext.Lectures.Where(x => x.Name == BusinessModelLectureName).FirstOrDefault(),
                },
            };

            foreach (Resource resource in resourcesList)
            {
                var dbResource = await dbContext.Resources.FirstOrDefaultAsync(x => x.Name == resource.Name);

                if (dbResource == null)
                {
                    await dbContext.Resources.AddAsync(resource);
                }
            }
        }
    }
}
