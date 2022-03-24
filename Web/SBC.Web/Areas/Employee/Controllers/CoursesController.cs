namespace SBC.Web.Areas.Employee.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Common;
    using SBC.Services.Data.Courses;
    using SBC.Web.ViewModels.Administration.Courses;

    public class CoursesController : EmployeesBaseController
    {
        private readonly ICoursesService courseService;

        public CoursesController(ICoursesService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await this.courseService.GetByIdAsync<CourseDetailsViewModel>(id);

            return this.GenericResponse(new ResultModel(result));
        }
    }
}
