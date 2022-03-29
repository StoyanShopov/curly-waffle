namespace SBC.Web.Areas.Employee.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Common;
    using SBC.Services.Data.Lectures;
    using SBC.Web.ViewModels.Administration.Lectures;

    public class LecturesController : EmployeesBaseController
    {
        private readonly ILecturesService lectureService;

        public LecturesController(ILecturesService lectureService)
        {
            this.lectureService = lectureService;
        }

        [HttpGet]
        [Route("All/{id}")]
        public async Task<ActionResult> Get(int skip, int id, int take)
        {
            var result = await this.lectureService.GetAllByCourseIdAsync<LectureViewModel>(skip, id);

            return this.GenericResponse(new ResultModel(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var result = await this.lectureService.GetByIdAsync<LectureViewModel>(id);

            return this.GenericResponse(new ResultModel(result));
        }
    }
}
