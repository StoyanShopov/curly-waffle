namespace SBC.Web.Areas.BusinessOwner.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Companies;
    using SBC.Services.Data.Infrastructures;
    using SBC.Services.Data.Users;
    using SBC.Web.ViewModels.BusinessOwner.Employees;

    public class CompaniesController : BusinessOwnerController
    {
        private readonly ICompaniesService companiesService;
        private readonly IUsersService usersService;

        public CompaniesController(ICompaniesService companiesService, IUsersService usersService)
        {
            this.companiesService = companiesService;
            this.usersService = usersService;
        }

        // Employee Controller
        [HttpGet]
        [Route("employees")]
        public async Task<ActionResult> GetEmployees(int skip)
            => this.GenericResponse(await this.companiesService.GetEmployeesAsync(this.User.Id(), skip));

        // Employee Controller
        [HttpPost]
        [Route("addEmployee")]
        public async Task<ActionResult> AddEmployee(CreateEmployeeInputModel model)
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());
            return this.GenericResponse(await this.companiesService.AddEmployeeAsync(model, companyId, this.User.Id()));
        }

        [HttpDelete]
        [Route("removeEmployee")]
        public async Task<ActionResult> RemoveEmployee(string employeeId)
            => this.GenericResponse(await this.companiesService.RemoveEmployeeAsync(employeeId));

        [HttpGet]
        [Route("activeCoaches")]
        public async Task<ActionResult> GetActiveCoaches()
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());
            return this.GenericResponse(await this.companiesService.GetActiveCoachesAsync(companyId));
        }

        [HttpGet]
        [Route("addCoach")]
        public async Task<ActionResult> SetCoachToActive(int coachId)
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());
            return this.GenericResponse(await this.companiesService.SetCoachToActiveAsync(coachId, companyId));
        }

        [HttpDelete]
        [Route("removeCoach")]
        public async Task<ActionResult> RemoveCoachFromActive(int coachId)
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());
            return this.GenericResponse(await this.companiesService.RemoveCoachAsync(coachId, companyId));
        }

        [HttpGet]
        [Route("activeCourses")]
        public async Task<ActionResult> GetActiveCourses()
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());
            return this.GenericResponse(await this.companiesService.GetActiveCoursesAsync(companyId));
        }

        [HttpGet]
        [Route("addCourse")]
        public async Task<ActionResult> SetCourseToActive(int courseId)
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());
            return this.GenericResponse(await this.companiesService.SetCourseToActiveAsync(courseId, companyId));
        }

        [HttpDelete]
        [Route("removeCourse")]
        public async Task<ActionResult> RemoveCourseFromActive(int courseId)
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());
            return this.GenericResponse(await this.companiesService.RemoveCourseAsync(courseId, companyId));
        }
    }
}
