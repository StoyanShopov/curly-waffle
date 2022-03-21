namespace SBC.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Courses;
    using SBC.Services.Data.Infrastructures;
    using SBC.Web.Areas.Employees.Controllers;
    using SBC.Web.ViewModels.Employees;

    public class EmployeesCoursesController : EmployeesBaseController
    {
        private readonly ICoursesService courseService;

        public EmployeesCoursesController(ICoursesService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var userId = this.User.Id();

            var courses = await this.courseService.GetAllByOwnerAsync(userId);

            return this.GenericResponse(courses);
        }
    }
}
