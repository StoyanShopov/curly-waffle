namespace SBC.Services.Data.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Admin.Contracts;
    using SBC.Services.Data.Coach.Contracts;
    using SBC.Services.Data.Company.Contracts;
    using SBC.Services.Data.Course.Contracts;
    using SBC.Web.ViewModels;
    using SBC.Web.ViewModels.Administration.Dashboard;

    public class DashboardService : IDasboardService
    {
        private readonly ICompanyService companyService;
        private readonly ICourseService courseService;
        private readonly ICoachService coachService;

        public DashboardService(ICompanyService companyService, ICourseService courseService, ICoachService coachService)
        {
            this.coachService = coachService;
            this.courseService = courseService;
            this.companyService = companyService;
        }

        public async Task<Result> GetDashboard()
        {
            var clients = await this.companyService.GetCountAsync();
            var courses = await this.courseService.GetCount();
            var coaches = await this.coachService.GetCount();

            var numberOfClients = this.ParseDiagramByCountAndMonths(new int[] { 45, 15, 25, 60, 30, 45 });
            var totalRevenue = this.ParseDiagramByCountAndMonths(new int[] { 1000, 800, 1000, 900, 1300, 1000 });

            return new ResultModel(new DashBoardViewModel
            {
                Clients = (int)clients.Data.Value,
                Revenue = 1245,
                Courses = (int)courses.Data.Value,
                Coaches = (int)coaches.Data.Value,
                NumberOfClients = this.ParseDiagramByCountAndMonths(new int[] { 45, 15, 25, 60, 30, 45 }),
                TotalRevenue = this.ParseDiagramByCountAndMonths(new int[] { 1000, 800, 1000, 900, 1300, 1000 }),
            });
        }

        private ICollection<DiagramViewModelPoint<int, string>> ParseDiagramByCountAndMonths(int[] hardCodeData) =>
                       hardCodeData
                           .Select((x, y) => new DiagramViewModelPoint<int, string>()
                           {
                               X = x,
                               Y = DateTimeFormatInfo.CurrentInfo.MonthNames[y].Substring(0, 3),
                           })
                           .ToList();
    }
}
