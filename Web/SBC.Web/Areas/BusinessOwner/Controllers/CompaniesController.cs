namespace SBC.Web.Areas.BusinessOwner.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Companies;
    using SBC.Services.Data.Infrastructures;
    using SBC.Services.Data.Users;
    using SBC.Web.ViewModels.BusinessOwner.Employees;

    using static SBC.Common.RoutesConstants;

    public class CompaniesController : BusinessOwnerController
    {
        private readonly ICompaniesService companiesService;
        private readonly IUsersService usersService;

        public CompaniesController(
            ICompaniesService companiesService,
            IUsersService usersService)
        {
            this.companiesService = companiesService;
            this.usersService = usersService;
        }

        [HttpGet]
        [Route(Employees)]
        public async Task<ActionResult> GetEmployees(int skip)
        {
            var result = await this.companiesService
                .GetEmployeesAsync(this.User.Id(), skip);

            return this.GenericResponse(result);
        }

        [HttpPost]
        [Route(AddEmployee)]
        public async Task<ActionResult> AddEmployeeForOwner(CreateEmployeeInputModel model)
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());

            var result = await this.companiesService
                .AddEmployeeAsync(model, companyId, this.User.Id());

            return this.GenericResponse(result);
        }

        [HttpDelete]
        [Route(RemoveEmployee)]
        public async Task<ActionResult> RemoveEmployeeForOwner(string employeeId)
        {
            var result = await this.companiesService.RemoveEmployeeAsync(employeeId);

            return this.GenericResponse(result);
        }

        [HttpGet]
        [Route(ActiveCoaches)]
        public async Task<ActionResult> GetActiveCoaches()
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());

            var result = await this.companiesService.GetActiveCoachesAsync(companyId);

            return this.GenericResponse(result);
        }

        [HttpGet]
        [Route(AddCoach)]
        public async Task<ActionResult> SetCoachToActive(int coachId)
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());

            var result = await this.companiesService
                .SetCoachToActiveAsync(coachId, companyId);

            return this.GenericResponse(result);
        }

        [HttpDelete]
        [Route(RemoveCoach)]
        public async Task<ActionResult> RemoveCoachFromActive(int coachId)
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());

            var result = await this.companiesService
                .RemoveCoachAsync(coachId, companyId);

            return this.GenericResponse(result);
        }

        [HttpGet]
        [Route(ActiveCourses)]
        public async Task<ActionResult> GetActiveCourses()
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());

            var result = await this.companiesService.GetActiveCoursesAsync(companyId);

            return this.GenericResponse(result);
        }

        [HttpGet]
        [Route(AddCourse)]
        public async Task<ActionResult> SetCourseToActive(int courseId)
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());

            var result = await this.companiesService
                .SetCourseToActiveAsync(courseId, companyId);

            return this.GenericResponse(result);
        }

        [HttpDelete]
        [Route(RemoveCourse)]
        public async Task<ActionResult> RemoveCourseFromActive(int courseId)
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());

            var result = await this.companiesService
                .RemoveCourseAsync(courseId, companyId);

            return this.GenericResponse(result);
        }
    }
}
