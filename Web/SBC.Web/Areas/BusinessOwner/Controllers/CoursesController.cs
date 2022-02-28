namespace SBC.Web.Areas.BusinessOwner.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Courses;

    public class CoursesController : BusinessOwnerController
    {
        private readonly ICoursesService coursesService;

        public CoursesController(ICoursesService coursesService)
        {
            this.coursesService = coursesService;
        }

        [HttpGet]
        [Route("/coursesCatalog")]
        public async Task<ActionResult> GetCoursesCatalog(int companyId)
            => this.GenericResponse(await this.coursesService.GetAllWithActive(companyId));
    }
}
