namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Common;
    using SBC.Services.Data.Lecture.Contracts;
    using SBC.Services.Data.Lecture.Models;
    using SBC.Web.ViewModels;

    public class LectureController : AdministrationController
    {
        private readonly ILectureService lectureService;

        public LectureController(ILectureService lectureService)
        {
            this.lectureService = lectureService;
        }

        [HttpGet]
        [Route("All/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await this.lectureService.GetAllByCourseIdAsync<LectureViewModel>(id);

            return this.GenericResponse(new ResultModel(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var result = await this.lectureService.GetByIdAsync<LectureViewModel>(id);

            return this.GenericResponse(new ResultModel(result));
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateLectureServiceModel lectureModel)
        {
            var result = await this.lectureService.CreateAsync(lectureModel);
            ;
            return this.GenericResponse(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, EditLectureServiceModel lectureModel)
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
