namespace SBC.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Data.Models;

    using static SBC.Common.GlobalConstants.LanguagesNamesConstants;

    internal class LanguagesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var languageList = new List<Language>()
            {
                new Language
                {
                    Name = English,
                    DeletedOn = null,
                    IsDeleted = false,
                },
                new Language
                {
                    Name = German,
                    DeletedOn = null,
                    IsDeleted = false,
                },
            };

            foreach (Language language in languageList)
            {
                var dbLanguage = await dbContext.Languages.FirstOrDefaultAsync(x => x.Name == language.Name);

                if (dbLanguage == null)
                {
                    await dbContext.Languages.AddAsync(language);
                }
            }
        }
    }
}
