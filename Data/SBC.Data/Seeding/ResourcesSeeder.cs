namespace SBC.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Data.Models;

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
                },
                new Resource
                {
                    Name = MarketingPDFResourceName,
                    FileUrl = MarketingPDFFileUrl,
                    Size = 200,
                    FileType = FileType.Pdf,
                    DeletedOn = null,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                },
                new Resource
                {
                    Name = DigitalMarketAudioResourceName,
                    FileUrl = DigitalMarketAudioFileUrl,
                    Size = 120,
                    FileType = FileType.Audio,
                    DeletedOn = null,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
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
