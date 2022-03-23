namespace SBC.Web.Areas.Employees.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Common;
    using SBC.Services.Data.Lectures;
    using SBC.Web.ViewModels.Administration.Lectures;

    public class EmployeeLectureController : EmployeesBaseController
    {
        private readonly ILecturesService lectureService;

        public EmployeeLectureController(ILecturesService lectureService)
        {
            this.lectureService = lectureService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int skip, int id)
        {
            var result = await this.lectureService.GetAllByCourseIdAsync<LectureViewModel>(skip, id);

            return this.GenericResponse(new ResultModel(result));
        }
    }
}
