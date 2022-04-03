namespace SBC.Services.Data.BusinessOwner
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Web.ViewModels.BusinessOwner.Dashboard;

    public class BusinessOwnerDashboardService : IBusinessOwnerDashboardService
    {
        private readonly IDeletableEntityRepository<Coach> coachesRepo;
        private readonly IDeletableEntityRepository<Course> coursesRepo;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepo;

        public BusinessOwnerDashboardService(
            IDeletableEntityRepository<Coach> coachesRepo,
            IDeletableEntityRepository<Course> coursesRepo,
            IDeletableEntityRepository<ApplicationUser> usersRepo)
        {
            this.coachesRepo = coachesRepo;
            this.coursesRepo = coursesRepo;
            this.usersRepo = usersRepo;
        }

        public async Task<Result> GetDashboardAsync(string userId)
        {
            var companyId = this.usersRepo
                .AllAsNoTracking()
                .Where(x => x.Id == userId)
                .Select(x => x.CompanyId)
                .FirstOrDefault();

            var employeesCount = await this.usersRepo
                .AllAsNoTracking()
                .Where(x => x.CompanyId == companyId)
                .ToListAsync();

            var coursesCount = await this.coursesRepo
                .AllAsNoTracking()
                .Where(x => x.Companies
                .Any(c => c.CompanyId == companyId))
                .ToListAsync();

            var coachesCount = await this.coachesRepo
                .AllAsNoTracking()
                .Where(x => x.ClientCompanies
                .Any(c => c.CompanyId == companyId))
                .ToListAsync();

            var result = new DashboardViewModel
            {
                EmployeesCount = employeesCount.Count,
                CoursesCount = coursesCount.Count,
                CoachesCount = coachesCount.Count,
            };

            return new ResultModel(result);
        }
    }
}
