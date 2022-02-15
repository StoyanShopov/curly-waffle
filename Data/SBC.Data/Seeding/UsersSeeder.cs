namespace SBC.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using SBC.Data.Models;

    using static SBC.Common.GlobalConstants.PasswordConstants;
    using static SBC.Common.GlobalConstants.RolesNamesConstants;

    internal class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            const string adminEmail = "admin@test.test";

            var adminUser = new ApplicationUser
            {
                Email = adminEmail,
                UserName = adminEmail,
            };

            await SeedUsersRoles(dbContext, userManager, adminUser, AdminPassword, AdministratorRoleName);

            const string ownerEmail = "owner@test.test";

            var ownerUser = new ApplicationUser
            {
                Email = ownerEmail,
                UserName = ownerEmail,
            };

            await SeedUsersRoles(dbContext, userManager, ownerUser, CompanyOwnerPassword, CompanyOwnerRoleName);

            var applicationUsersList = new List<ApplicationUser>()
                {
                    new ApplicationUser
                    {
                        FirstName = "Vasil",
                        LastName = "Vasilev",
                        Email = "vasil@test.test",
                        UserName = "vasil@test.test",
                        PhoneNumber = "+359 888000333",
                        PhotoUrl = "https://berrysphere.co.ke/wp-content/uploads/2021/08/85120553-696x466.jpg",
                        ProfileSummary = "Vasil Vasilev Description Summary",
                        DeletedOn = null,
                        IsDeleted = false,
                    },
                    new ApplicationUser
                    {
                        FirstName = "Gergana",
                        LastName = "Popova",
                        Email = "gergana@test.test",
                        UserName = "gergana@test.test",
                        PhoneNumber = "+359 888000444",
                        PhotoUrl = "https://images.pexels.com/photos/47547/squirrel-animal-cute-rodents-47547.jpeg",
                        ProfileSummary = "Gergana Popova Description Summary",
                        DeletedOn = null,
                        IsDeleted = false,
                    },
                    new ApplicationUser
                    {
                        FirstName = "Nikolay",
                        LastName = "Stefanov",
                        Email = "nikolay@test.test",
                        UserName = "nikolay@test.test",
                        PhoneNumber = "+359 888000555",
                        PhotoUrl = "https://images.pexels.com/photos/145939/pexels-photo-145939.jpeg",
                        ProfileSummary = "Nikolay Stefanov Description Summary",
                        DeletedOn = null,
                        IsDeleted = false,
                    },
                    new ApplicationUser
                    {
                        FirstName = "Emil",
                        LastName = "Emilov",
                        Email = "emil@test.test",
                        UserName = "emil@test.test",
                        PhoneNumber = "+359 888000666",
                        PhotoUrl = "https://ichef.bbci.co.uk/images/ic/624x351/p049tgdb.jpg",
                        ProfileSummary = "Emil Emilov Description Summary",
                        DeletedOn = null,
                        IsDeleted = false,
                    },
                    new ApplicationUser
                    {
                        FirstName = "Maria",
                        LastName = "Toncheva",
                        Email = "maria@test.test",
                        UserName = "maria@test.test",
                        PhoneNumber = "+359 888000888",
                        PhotoUrl = "https://themysteryboy.files.wordpress.com/2012/05/cute_cat_1_by_ashish11.jpg",
                        ProfileSummary = "Maria Toncheva Description Summary",
                        DeletedOn = null,
                        IsDeleted = false,
                    },
                    new ApplicationUser
                    {
                        FirstName = "Ivan",
                        LastName = "Ivanov",
                        Email = "ivan@test.test",
                        UserName = "ivan@test.test",
                        PhoneNumber = "+359 888000333",
                        PhotoUrl = "https://i.natgeofe.com/n/f4d64d53-07ce-4933-a76e-1d405eec3473/giraffe_thumb_3x4.JPG",
                        ProfileSummary = "Ivan Ivanov Description Summary",
                        DeletedOn = null,
                        IsDeleted = false,
                    },
                };

            foreach (ApplicationUser applicationUser in applicationUsersList)
            {
                await SeedUsersRoles(dbContext, userManager, applicationUser, EmployeePassword, CompanyEmployeeRoleName);
            }

        }

        private static async Task SeedUsersRoles(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, ApplicationUser user, string password, string roleName)
        {
            var dbApplicationUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == user.Email);

            if (dbApplicationUser == null)
            {
                await userManager.CreateAsync(user, password);

                await userManager.AddToRoleAsync(user, roleName);
            }
        }
    }
}
