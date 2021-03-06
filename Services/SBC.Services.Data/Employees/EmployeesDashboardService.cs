namespace SBC.Services.Data.Employees
{
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Mapping;
    using SBC.Web.ViewModels.Employees.Coaches;
    using SBC.Web.ViewModels.Employees.Courses;
    using SBC.Web.ViewModels.Employees.Dashboard;

    using static SBC.Common.ErrorConstants.Employee;

    public class EmployeesDashboardService : IEmployeesDashboardService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> applicationUserRepository;
        private readonly IDeletableEntityRepository<UserCoachSession> userCoachSessionsRepository;
        private readonly IDeletableEntityRepository<UserCourse> userCoursesRepository;

        public EmployeesDashboardService(
            IDeletableEntityRepository<ApplicationUser> applicationUserRepository,
            IDeletableEntityRepository<UserCoachSession> userCoachSessionsRepository,
            IDeletableEntityRepository<UserCourse> userCoursesRepository)
        {
            this.applicationUserRepository = applicationUserRepository;
            this.userCoachSessionsRepository = userCoachSessionsRepository;
            this.userCoursesRepository = userCoursesRepository;
        }

        public async Task<Result> GetAsync(string userId)
        {
            var user = await this.applicationUserRepository
                .AllAsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, EmployeeCantBeNull);
            }

            var userCoachesSessions = await this.userCoachSessionsRepository
                .AllAsNoTracking()
                .Include(c => c.Coach)
                .Where(uc => uc.UserId == userId)
                .To<UserCoachSessionViewModel>()
                .Distinct()
                .ToListAsync();

            var userCourses = await this.userCoursesRepository
                .AllAsNoTracking()
                .Include(c => c.Course)
                .Where(x => x.UserId == userId)
                .To<UserCourseViewModel>()
                .ToListAsync();

            var resultModel = new DashboardViewModel()
            {
                UserCoachSessions = userCoachesSessions,
                UserCourses = userCourses,
            };

            return new ResultModel(resultModel);
        }
    }
}
