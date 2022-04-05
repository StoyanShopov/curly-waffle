    namespace SBC.Web.Areas.Employee.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Common;
    using SBC.Services.Data.Courses;
    using SBC.Services.Data.Infrastructures;
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
            var result = await this.courseService
                .GetByIdAsync<CourseDetailsViewModel>(id);

            return this.GenericResponse(new ResultModel(result));
        }

        [HttpGet("modalDetails/{id}")]
        public async Task<ActionResult> GetDetails(int id)
        {
            var result = await this.courseService
                .GetByIdEmployeeAsync(id);

            return this.GenericResponse(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetByOwner()
        {
            var userId = this.User.Id();

            var result = await this.courseService
                .GetAllByOwnerAsync(userId);

            return this.GenericResponse(result);
        }

        [HttpPost("{courseId}")]
        public async Task<ActionResult> Enroll(int courseId)
        {
            var userId = this.User.Id();

            var result = await this.courseService
                .EnrollCourse(userId, courseId);

            return this.GenericResponse(result);

        }
    }
}
