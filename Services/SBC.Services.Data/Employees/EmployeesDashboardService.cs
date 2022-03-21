﻿namespace SBC.Services.Data.Employees
{
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Users;

    public class EmployeesDashboardService : IEmployeesDashboardService
    {
        private readonly IDeletableEntityRepository<UserCourse> userCoursesRepository;
        private readonly IDeletableEntityRepository<UserCoachSession> userCoachSessionsRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> applicationUserRepository;

        public EmployeesDashboardService(IDeletableEntityRepository<UserCoachSession> userCoachSessionsRepository, IDeletableEntityRepository<UserCourse> userCoursesRepository, IUsersService usersService, IDeletableEntityRepository<ApplicationUser> applicationUserRepository)
        {
            this.userCoachSessionsRepository = userCoachSessionsRepository;
            this.userCoursesRepository = userCoursesRepository;
            this.applicationUserRepository = applicationUserRepository;
        }

        public async Task<Result> GetUserCoacheSessionsAsync(string userId)
        {
            var user = await this.applicationUserRepository.AllAsNoTracking().FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, "User cannot be null");
            }

            var userCoachesSessions = await this.userCoachSessionsRepository
                .AllAsNoTracking()
                .Where(uc => uc.UserId == userId)
                .Distinct()
                .ToListAsync();

            return new ResultModel(userCoachesSessions);
        }

        public async Task<Result> GetUserCoursesAsync(string userId)
        {

            return null;
        }
    }
}
