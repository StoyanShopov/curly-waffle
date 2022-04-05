namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Courses;
    using SBC.Web.ViewModels.Administration.Courses;

    public class CoursesController : AdministrationController
    {
        private readonly ICoursesService courseService;

        public CoursesController(
            ICoursesService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await this.courseService.GetAllAsync<CourseDetailsViewModel>();

            return this.GenericResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await this.courseService.GetByIdAsync<CourseDetailsViewModel>(id);

            return this.GenericResponse(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCourseInputModel courseModel)
        {
            var result = await this.courseService.CreateAsync(courseModel);

            return this.GenericResponse(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int? id, EditCourseInputModel courseModel)
        {
            var result = await this.courseService.EditAsync(id, courseModel);

            return this.GenericResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await this.courseService.DeleteByIdAsync(id);

            return this.GenericResponse(result);
        }
    }
}
