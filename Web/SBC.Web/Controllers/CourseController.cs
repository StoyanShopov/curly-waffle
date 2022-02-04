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

        [HttpPost]
        public async Task<ActionResult> Post(CreateCourseServiceModel courseModel)
        {
            var result = await this.courseService.CreateAsync(courseModel);

            return this.GenericResponse(result);
        }
    }
}
