namespace SBC.Web.Areas.BusinessOwner.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Companies;
    using SBC.Services.Data.Infrastructures;
    using SBC.Services.Data.Users;
    using SBC.Web.ViewModels.BusinessOwner.Employees;

    public class CompanyController : BusinessOwnerController
    {
        private readonly ICompaniesService companiesService;
        private readonly IUsersService usersService;

        public CompanyController(ICompaniesService companiesService, IUsersService usersService)
        {
            this.companiesService = companiesService;
            this.usersService = usersService;
        }

        [HttpGet]
        [Route("employees")]
        public async Task<ActionResult> GetEmployees(int skip)
            => this.GenericResponse(await this.companiesService.GetEmployees(this.User.Id(), skip));

        [HttpPost]
        [Route("addEmployee")]
        public async Task<ActionResult> AddEmployee(CreateEmployeeInputModel model)
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());
            return this.GenericResponse(await this.companiesService.AddEmployee(model, companyId, this.User.Id()));
        }

        [HttpDelete]
        [Route("removeEmployee")]
        public async Task<ActionResult> RemoveEmployee(string employeeId)
            => this.GenericResponse(await this.companiesService.RemoveEmployee(employeeId));

        [HttpGet]
        [Route("activeCoaches")]
        public async Task<ActionResult> GetActiveCoaches()
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());
            return this.GenericResponse(await this.companiesService.GetActiveCoaches(companyId));
        }

        [HttpPost]
        [Route("addCoach")]
        public async Task<ActionResult> SetCoachToActive(int coachId)
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());
            return this.GenericResponse(await this.companiesService.SetCoachToActive(coachId, companyId));
        }

        [HttpDelete]
        [Route("removeCoach")]
        public async Task<ActionResult> RemoveCoachFromActive(int coachId)
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());
            return this.GenericResponse(await this.companiesService.RemoveCoach(coachId, companyId));
        }

        [HttpGet]
        [Route("activeCourses")]
        public async Task<ActionResult> GetActiveCourses()
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());
            return this.GenericResponse(await this.companiesService.GetActiveCourses(companyId));
        }

        [HttpPost]
        [Route("addCourse")]
        public async Task<ActionResult> SetCourseToActive(int courseId)
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());
            return this.GenericResponse(await this.companiesService.SetCourseToActive(courseId, companyId));
        }

        [HttpDelete]
        [Route("removeCourse")]
        public async Task<ActionResult> RemoveCourseFromActive(int courseId)
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());
            return this.GenericResponse(await this.companiesService.RemoveCourse(courseId, companyId));
        }
    }
}
