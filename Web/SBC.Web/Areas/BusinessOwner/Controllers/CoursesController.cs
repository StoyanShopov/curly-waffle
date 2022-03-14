namespace SBC.Web.Areas.BusinessOwner.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Courses;
    using SBC.Services.Data.Infrastructures;
    using SBC.Services.Data.Users;

    public class CoursesController : BusinessOwnerController
    {
        private readonly ICoursesService coursesService;
        private readonly IUsersService usersService;

        public CoursesController(ICoursesService coursesService, IUsersService usersService)
        {
            this.coursesService = coursesService;
            this.usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult> GetCoursesCatalog(int skip)
        {
            var companyId = this.usersService.GetCompanyId(this.User.Id());
            return this.GenericResponse(await this.coursesService.GetAllWithActive(companyId, skip));
        }
    }
}
