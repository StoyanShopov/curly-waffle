namespace SBC.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using SBC.Data.Models;

    using static SBC.Common.GlobalConstants.CompaniesNamesConstants;
    using static SBC.Common.GlobalConstants.EmailsConstants;
    using static SBC.Common.GlobalConstants.PasswordConstants;
    using static SBC.Common.GlobalConstants.RolesNamesConstants;
    using static SBC.Common.GlobalConstants.EmployeesPhotoUrlConstants;

    internal class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            const string adminEmail = AdminEmail;
            var company = await dbContext.Companies.FirstOrDefaultAsync(x => x.Name == SoftUniCompanyName);

            var adminUser = new ApplicationUser
            {
                FirstName = "Admin",
                LastName = "Adminov",
                Email = adminEmail,
                UserName = adminEmail,
                PhotoUrl = AdminAdminovPhotoUrl,
                CompanyId = 1,
                ProfileSummary = "Admin Summary",
            };

            await SeedUsersRoles(dbContext, userManager, adminUser, AdminPassword, AdministratorRoleName);

            const string ownerEmail = OwnerEmail;

            var ownerUser = new ApplicationUser
            {
                FirstName = "Owner",
                LastName = "Ownerov",
                Email = ownerEmail,
                UserName = ownerEmail,
                PhotoUrl = OwnerOwnerovPhotoUrl,
                CompanyId = company.Id,
                ProfileSummary = "Owner Summary",
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
                        PhotoUrl = VasilVasilevPhotoUrl,
                        ProfileSummary = "Vasil Vasilev Description Summary",
                        DeletedOn = null,
                        IsDeleted = false,
                        CompanyId = company.Id,
                        Manager = ownerUser,
                    },
                    new ApplicationUser
                    {
                        FirstName = "Gergana",
                        LastName = "Popova",
                        Email = "gergana@test.test",
                        UserName = "gergana@test.test",
                        PhoneNumber = "+359 888000444",
                        PhotoUrl = GerganaPopovaPhotoUrl,
                        ProfileSummary = "Gergana Popova Description Summary",
                        DeletedOn = null,
                        IsDeleted = false,
                        CompanyId = company.Id,
                        Manager = ownerUser,
                    },
                    new ApplicationUser
                    {
                        FirstName = "Nikolay",
                        LastName = "Stefanov",
                        Email = "nikolay@test.test",
                        UserName = "nikolay@test.test",
                        PhoneNumber = "+359 888000555",
                        PhotoUrl = NikolayStefanovPhotoUrl,
                        ProfileSummary = "Nikolay Stefanov Description Summary",
                        DeletedOn = null,
                        IsDeleted = false,
                        CompanyId = company.Id,
                        Manager = ownerUser,
                    },
                    new ApplicationUser
                    {
                        FirstName = "Emil",
                        LastName = "Emilov",
                        Email = "emil@test.test",
                        UserName = "emil@test.test",
                        PhoneNumber = "+359 888000666",
                        PhotoUrl = EmilEmilovPhotoUrl,
                        ProfileSummary = "Emil Emilov Description Summary",
                        DeletedOn = null,
                        IsDeleted = false,
                        CompanyId = company.Id,
                        Manager = ownerUser,
                    },
                    new ApplicationUser
                    {
                        FirstName = "Maria",
                        LastName = "Toncheva",
                        Email = "maria@test.test",
                        UserName = "maria@test.test",
                        PhoneNumber = "+359 888000888",
                        PhotoUrl = MariaTonchevaPhotoUrl,
                        ProfileSummary = "Maria Toncheva Description Summary",
                        DeletedOn = null,
                        IsDeleted = false,
                        CompanyId = company.Id,
                        Manager = ownerUser,
                    },
                    new ApplicationUser
                    {
                        FirstName = "Ivan",
                        LastName = "Ivanov",
                        Email = "ivan@test.test",
                        UserName = "ivan@test.test",
                        PhoneNumber = "+359 888000333",
                        PhotoUrl = IvanIvanovPhotoUrl,
                        ProfileSummary = "Ivan Ivanov Description Summary",
                        DeletedOn = null,
                        IsDeleted = false,
                        CompanyId = company.Id,
                        Manager = ownerUser,
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
