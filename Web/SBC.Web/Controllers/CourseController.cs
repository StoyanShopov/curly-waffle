namespace SBC.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Course.Contracts;
    using SBC.Services.Data.Course.Models;

    public class CourseController : ApiController
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await this.courseService.GetAllAsync();

            return this.GenericResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await this.courseService.GetByIdAsync(id);

            return this.GenericResponse(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateCourseServiceModel courseModel)
        {
            var result = await this.courseService.CreateAsync(courseModel);

            return this.GenericResponse(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put(EditCourseServiceModel courseModel)
        {
            var result = await this.courseService.EditAsync(courseModel);

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
