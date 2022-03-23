namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SBC.Common;
    using SBC.Services.Data.Lectures;
    using SBC.Web.ViewModels.Administration.Lectures;

    public class LecturesController : AdministrationController
    {
        private readonly ILecturesService lectureService;

        public LecturesController(ILecturesService lectureService)
        {
            this.lectureService = lectureService;
        }

        [HttpGet]
        [Authorize(Roles = "Employee")]
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

        [HttpPost]
        public async Task<ActionResult> Post(CreateLectureInputModel lectureModel)
        {
            var result = await this.lectureService.CreateAsync(lectureModel);

            return this.GenericResponse(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, EditLectureInputModel lectureModel)
        {
            var result = await this.lectureService.EditAsync(id, lectureModel);

            return this.GenericResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var result = await this.lectureService.DeleteByIdAsync(id);

            return this.GenericResponse(result);
        }
    }
}
