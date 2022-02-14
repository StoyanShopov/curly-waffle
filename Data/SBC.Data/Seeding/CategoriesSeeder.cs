namespace SBC.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Data.Models;

    using static SBC.Common.SBC.Common.GlobalConstants.CategoriesNamesConstants;

    internal class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var categoriesList = new List<Category>()
            {
                new Category
                {
                    Name = Marketing,
                    DeletedOn = null,
                    IsDeleted = false,
                },
                new Category
                {
                    Name = Design,
                    DeletedOn = null,
                    IsDeleted = false,
                },
                new Category
                {
                    Name = Art,
                    DeletedOn = null,
                    IsDeleted = false,
                },
            };

            foreach (Category category in categoriesList)
            {
                var dbCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Name == category.Name);

                if (dbCategory == null)
                {
                    await dbContext.Categories.AddAsync(category);
                }
            }
        }
    }
}
