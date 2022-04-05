namespace SBC.Services.Data.Companies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Mapping;
    using SBC.Web.ViewModels.Administration.Companies;
    using SBC.Web.ViewModels.BusinessOwner.Coaches;
    using SBC.Web.ViewModels.BusinessOwner.Courses;
    using SBC.Web.ViewModels.BusinessOwner.Employees;
    using SBC.Web.ViewModels.Company;

    using static SBC.Common.ErrorConstants.CompanyConstants;
    using static SBC.Common.GlobalConstants.ClientConstants;
    using static SBC.Common.GlobalConstants.RolesNamesConstants;

    public class CompaniesService : ICompaniesService
    {
        private readonly IDeletableEntityRepository<Company> companiesRepository;
        private readonly IDeletableEntityRepository<Coach> coachesRepository;
        private readonly IDeletableEntityRepository<Course> coursesRepository;
        private readonly IDeletableEntityRepository<CompanyCoach> companyCoachesRepository;
        private readonly IDeletableEntityRepository<CompanyCourse> companyCoursesRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly RoleManager<ApplicationRole> roleManager;

        public CompaniesService(
            IDeletableEntityRepository<Company> companiesRepository,
            IDeletableEntityRepository<Coach> coachesRepository,
            IDeletableEntityRepository<Course> coursesRepository,
            IDeletableEntityRepository<CompanyCoach> companyCoachesRepository,
            IDeletableEntityRepository<CompanyCourse> companyCoursesRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            RoleManager<ApplicationRole> roleManager)
        {
            this.companiesRepository = companiesRepository;
            this.coachesRepository = coachesRepository;
            this.coursesRepository = coursesRepository;
            this.companyCoachesRepository = companyCoachesRepository;
            this.companyCoursesRepository = companyCoursesRepository;
            this.usersRepository = usersRepository;
            this.roleManager = roleManager;
        }

        public async Task<Result> AddAsync(CreateCompanyInputModel model)
        {
            var existsByName = await this.ExistsByNameAsync(model.Name);

            if (existsByName)
            {
                var error = string.Format(ExistsByName, model.Name);

                return new ErrorModel(HttpStatusCode.BadRequest, error);
            }

            var existsByEmail = await this.ExistsByEmailAsync(model.Email);

            if (existsByEmail)
            {
                var error = string.Format(ExistsByEmail, model.Email);

                return new ErrorModel(HttpStatusCode.BadRequest, error);
            }

            var company = new Company
            {
                Name = model.Name,
                Email = model.Email,
                LogoUrl = model.LogoUrl,
            };

            await this.companiesRepository.AddAsync(company);
            await this.companiesRepository.SaveChangesAsync();

            return true;
        }

        public async Task<Result> AddEmployeeAsync(
            CreateEmployeeInputModel input,
            int companyId,
            string userId)
        {
            var user = await this.usersRepository
                .All()
                .Where(x => x.Email == input.Email)
                .FirstOrDefaultAsync();

            if (user != null)
            {
                if (user.FirstName == input.FullName.Split(" ")[0] &&
                    user.LastName == input.FullName.Split(" ")[1] &&
                    user.ManagerId == null &&
                    user.CompanyId == null)
                {
                    user.ManagerId = userId;
                    user.CompanyId = companyId;
                }
                else if (user.FirstName != input.FullName.Split(" ")[0] ||
                    user.LastName != input.FullName.Split(" ")[1])
                {
                    var error = string.Format(NotExistsByFullName, input.FullName);

                    return new ErrorModel(HttpStatusCode.BadRequest, error);
                }
                else if (user.ManagerId != null || user.CompanyId != null)
                {
                    var error = string.Format(AlreadyAddedToACompany);

                    return new ErrorModel(HttpStatusCode.BadRequest, error);
                }
            }
            else
            {
                var error = string.Format(NotExistsByEmail, input.Email);

                return new ErrorModel(HttpStatusCode.BadRequest, error);
            }

            await this.usersRepository.SaveChangesAsync();

            return new ResultModel(user);
        }

        public async Task<Result> GetActiveCoachesAsync(int companyId)
        {
            var activeCoaches = await this.coachesRepository
                .AllAsNoTracking()
                .Where(c => c.ClientCompanies.Any(x => x.CompanyId == companyId))
                .Select(x => new ActiveCoachViewModel
                {
                    Id = x.Id,
                    FullName = $"{x.FirstName} {x.LastName}",
                    CategoryByDefault = x.Categories.Count == 0
                        ? "Common"
                        : x.Categories.FirstOrDefault().Category.Name,
                    PricePerSession = x.PricePerSession,
                    ImageUrl = x.ImageUrl,
                    CompanyLogoUrl = x.CompanyId != null ? x.Company.LogoUrl : "Null",
                })
                .ToListAsync();

            return new ResultModel(activeCoaches);
        }

        public async Task<Result> GetActiveCoursesAsync(int companyId)
        {
            var activeCourses = await this.coursesRepository
               .AllAsNoTracking()
               .Where(c => c.Companies.Any(x => x.CompanyId == companyId))
               .Include(x => x.Coach)
               .ThenInclude(x => x.Company)
               .Select(x => new ActiveCourseViewModel
               {
                   Id = x.Id,
                   Title = x.Title,
                   PricePerPerson = x.PricePerPerson,
                   PictureUrl = x.PictureUrl,
                   CategoryId = x.CategoryId,
                   LanguageId = x.LanguageId,
                   CoachFullName = $"{x.Coach.FirstName} {x.Coach.LastName}",
                   CategoryName = x.Category.Name,
                   CompanyLogoUrl = x.Coach.CompanyId != null
                        ? x.Coach.Company.LogoUrl
                        : "Null",
               })
               .ToListAsync();

            return new ResultModel(activeCourses);
        }

        public async Task<Result> GetAllAsync<TModel>()
        {
            var result = await this.companiesRepository
              .AllAsNoTracking()
              .To<CompanyViewModel>()
              .ToListAsync();

            return new ResultModel(result);
        }

        public async Task<Result> GetEmailByIdAsync(int id)
        {
            var result = await this.companiesRepository
                .AllAsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            return new ResultModel(result);
        }

        public async Task<Result> GetEmployeesAsync(
            string managerId,
            int skip = default,
            int take = TakeDefaultValue)
        {
            var employeesCount = await this.usersRepository
                .AllAsNoTracking()
                .Where(m => m.ManagerId == managerId)
                .CountAsync();

            var isViewMoreAvailable = (employeesCount - skip - take) > 0;

            var portions = await this.usersRepository
                .AllAsNoTracking()
                .Where(u => u.ManagerId == managerId)
                .OrderByDescending(u => u.CreatedOn)
                .Skip(skip)
                .Take(take)
                .Select(x => new EmployeeViewModel
                {
                    Email = x.Email,
                    Id = x.Id,
                    FullName = $"{x.FirstName} {x.LastName}",
                })
                .ToListAsync();

            var employees = new Web.ViewModels.BusinessOwner.Employees.EmployeesViewModel
            {
                Portions = portions,
                ViewMoreAvailable = isViewMoreAvailable,
                Count = employeesCount,
            };

            return new ResultModel(employees);
        }

        public async Task<Result> RemoveEmployeeAsync(string employeeId)
        {
            var employeeToRemove = this.usersRepository
                .All()
                .Where(x => x.Id == employeeId)
                .FirstOrDefault();

            employeeToRemove.ManagerId = null;
            employeeToRemove.CompanyId = null;

            await this.usersRepository.SaveChangesAsync();

            return new ResultModel(employeeToRemove);
        }

        public async Task<Result> RemoveCoachAsync(int coachId, int companyId)
        {
            var coach = this.companyCoachesRepository
                .All()
                .Where(x => x.CompanyId == companyId && x.CoachId == coachId)
                .FirstOrDefault();

            this.companyCoachesRepository.HardDelete(coach);

            await this.companyCoachesRepository.SaveChangesAsync();

            return new ResultModel(coach);
        }

        public async Task<Result> RemoveCourseAsync(int courseId, int companyId)
        {
            var activeCourse = this.companyCoursesRepository
                .All()
                .Where(x => x.CourseId == courseId && x.CompanyId == companyId)
                .FirstOrDefault();

            this.companyCoursesRepository.HardDelete(activeCourse);

            await this.companyCoursesRepository.SaveChangesAsync();

            return new ResultModel(activeCourse);
        }

        public async Task<Result> SetCoachToActiveAsync(int coachId, int companyId)
        {
            var newActiveCoach = new CompanyCoach
            {
                CompanyId = companyId,
                CoachId = coachId,
                IsDeleted = false,
                HireDate = DateTime.UtcNow,
            };

            await this.companyCoachesRepository.AddAsync(newActiveCoach);
            await this.companyCoachesRepository.SaveChangesAsync();

            return new ResultModel(newActiveCoach);
        }

        public async Task<Result> SetCourseToActiveAsync(int courseId, int companyId)
        {
            var newActiveCourse = new CompanyCourse
            {
                CourseId = courseId,
                CompanyId = companyId,
                IsDeleted = false,
                PurchaseDate = DateTime.UtcNow,
            };

            await this.companyCoursesRepository.AddAsync(newActiveCourse);
            await this.companyCoursesRepository.SaveChangesAsync();

            return new ResultModel(newActiveCourse);
        }

        // TODO: Improve
        public Task<IEnumerable<string>> GetAllEmployeesAsync(string companyName)
        {
            var result = this.companiesRepository
                .AllAsNoTracking()
                .Where(c => c.Name.ToLower() == companyName.ToLower())
                .Select(c => c.Employees.Select(e => e.Email))
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<int> GetCountAsync()
        {
            var result = await this.companiesRepository
               .AllAsNoTracking()
               .CountAsync();

            return result;
        }

        public async Task<int> GetIdByNameAsync(string name)
        {
            var result = await this.companiesRepository
               .AllAsNoTracking()
               .Where(c => c.Name.ToLower() == name.ToLower())
               .Select(c => c.Id)
               .FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            var result = await this.companiesRepository
                 .AllAsNoTracking()
                 .AnyAsync(c => c.Email.ToLower() == email.ToLower());

            return result;
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            var result = await this.companiesRepository
                          .AllAsNoTracking()
                          .AnyAsync(c => c.Name.ToLower() == name.ToLower());

            return result;
        }

        public async Task<bool> ExistsOwnerAsync(string name)
        {
            var role = await this.roleManager.FindByNameAsync(CompanyOwnerRoleName);

            var result = await this.companiesRepository
                  .AllAsNoTracking()
                  .Include(c => c.Employees)
                  .ThenInclude(e => e.Roles)
                  .Where(c => c.Name.ToLower() == name.ToLower())
                  .AnyAsync(c =>
                      c.Employees.Any(e =>
                          e.Roles.Any(r => r.RoleId == role.Id)));

            return result;
        }
    }
}
