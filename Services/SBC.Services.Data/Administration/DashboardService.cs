namespace SBC.Services.Data.Admin
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Services.Data.Coaches;
    using SBC.Services.Data.Companies;
    using SBC.Services.Data.Courses;
    using SBC.Web.ViewModels;
    using SBC.Web.ViewModels.Administration.Dashboard;

    public class DashboardService : IDasboardService
    {
        private readonly ICompaniesService companyService;
        private readonly ICoursesService courseService;
        private readonly ICoachesService coachService;

        public DashboardService(ICompaniesService companyService, ICoursesService courseService, ICoachesService coachService)
        {
            this.coachService = coachService;
            this.courseService = courseService;
            this.companyService = companyService;
        }

        public async Task<Result> GetDashboardAsync()
        {
            var coaches = await this.coachService.GetCountAsync();
            var clients = await this.companyService.GetCountAsync();
            var courses = await this.courseService.GetCountAsync();

            var numberOfClients = this.ParseDiagramByCountAndMonths(new int[] { 45, 15, 25, 60, 30, 45 });
            var totalRevenue = this.ParseDiagramByCountAndMonths(new int[] { 1000, 800, 1000, 900, 1300, 1000 });

            return new ResultModel(new DashboardViewModel
            {
                Clients = clients,
                Revenue = 1245,
                Courses = courses,
                Coaches = coaches,
                NumberOfClients = this.ParseDiagramByCountAndMonths(new int[] { 45, 15, 25, 60, 30, 45 }),
                TotalRevenue = this.ParseDiagramByCountAndMonths(new int[] { 1000, 800, 1000, 900, 1300, 1000 }),
            });
        }

        private ICollection<DiagramViewModelPoint<int, string>> ParseDiagramByCountAndMonths(int[] hardCodeData) =>
                       hardCodeData
                           .Select((x, y) => new DiagramViewModelPoint<int, string>()
                           {
                               X = x,
                               Y = DateTimeFormatInfo.CurrentInfo.MonthNames[y][..3],
                           })
                           .ToList();
    }
}
