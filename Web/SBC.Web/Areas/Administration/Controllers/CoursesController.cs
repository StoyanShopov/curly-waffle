namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using SBC.Common;
    using SBC.Data.Models;
    using SBC.Services.Data.Courses;
    using SBC.Services.Data.Infrastructures;
    using SBC.Web.Infrastructures.Hub;
    using SBC.Web.ViewModels.Administration.Courses;

    public class CoursesController : AdministrationController
    {
        private readonly ICoursesService courseService;
       // private readonly NotificationHub notificationHubContext;

        public CoursesController(
            ICoursesService courseService)
           // NotificationHub notificationHubContext)
        {
            this.courseService = courseService;
            //this.notificationHubContext = notificationHubContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await this.courseService.GetAllAsync<CourseDetailsViewModel>();

            return this.GenericResponse(new ResultModel(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await this.courseService.GetByIdAsync<CourseDetailsViewModel>(id);

            return this.GenericResponse(new ResultModel(result));
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateCourseInputModel courseModel)
        {
            var result = await this.courseService.CreateAsync(courseModel);

            return this.GenericResponse(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int? id, EditCourseInputModel courseModel)
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
