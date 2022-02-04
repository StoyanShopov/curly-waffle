namespace SBC.Services.Data.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Admin.Contracts;
    using SBC.Services.Data.Admin.Models;
    using SBC.Web.ViewModels;
    using SBC.Web.ViewModels.Administration.Dashboard;

    public class ProfileService : IProfileService
    {
        private readonly IDeletableEntityRepository<Company> companyRepository;
        private readonly IDeletableEntityRepository<Course> courseRepository;
        private readonly IDeletableEntityRepository<Coach> coacheRepository;

        public ProfileService(IDeletableEntityRepository<Coach> coacheRepository, IDeletableEntityRepository<Course> courseRepository, IDeletableEntityRepository<Company> companyRepository)
        {
            this.coacheRepository = coacheRepository;
            this.courseRepository = courseRepository;
            this.companyRepository = companyRepository;
        }

        public Task<Result> UpdateProfile(AdminSerivceModel adminSerivceModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result> GetCompanies(int page)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Result> GetDashboard() => new ResultModel(new DashBoardViewModel
        {
            Clients = await this.companyRepository.AllAsNoTracking().CountAsync(),
            Revenue = 1245,
            Courses = await this.courseRepository.AllAsNoTracking().CountAsync(),
            Coaches = await this.coacheRepository.AllAsNoTracking().CountAsync(),
            NumberOfClients = this.ParseDiagramByCountAndMonths(this.companyRepository.AllAsNoTrackingWithDeleted(), 6),

        // TotalRevenue = this.ParseDiagramByCountAndMonths(??,6)
        });

        public Task<Result> CreateComapany(CompanyServiceModel companyServiceModel)
        {
            throw new NotImplementedException();
        }

        private ICollection<DiagramViewModelPoint<int, string>> ParseDiagramByCountAndMonths(IQueryable<object> companies, int monthsCount)
        {
            this.companyRepository.All()
             .Where(c => c.DeletedOn.Value.Month >= System.DateTime.Now.Month - monthsCount)
             .Select(c => new DiagramViewModelPoint<int, string>() { })
             .ToList();
            throw new NotImplementedException();
        }
    }
}
