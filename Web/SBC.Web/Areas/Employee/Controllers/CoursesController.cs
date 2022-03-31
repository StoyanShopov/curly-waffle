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
            var result = await this.courseService.GetByIdAsync<CourseDetailsViewModel>(id);

            return this.GenericResponse(new ResultModel(result));
        }

        [HttpGet("modalDetails/{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var course = await this.courseService.GetByIdEmployeeAsync(id);

            return this.GenericResponse(course);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var userId = this.User.Id();

            var courses = await this.courseService.GetAllByOwnerAsync(userId);

            return this.GenericResponse(courses);
        }

        [HttpPost("{courseId}")]
        public async Task<ActionResult> PostAsync(int courseId)
        {
            var userId = this.User.Id();

            var isEnrolled = await this.courseService.EnrollCourseAsync(userId, courseId);

            return this.GenericResponse(isEnrolled);
        }
    }
}
