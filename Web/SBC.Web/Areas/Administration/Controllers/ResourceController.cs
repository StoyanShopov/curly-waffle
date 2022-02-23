namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Common;
    using SBC.Services.Data.Resource.Contracts;
    using SBC.Web.ViewModels.Resource;

    public class ResourceController : AdministrationController
    {
        private readonly IResourceService resourceService;

        public ResourceController(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }

        [HttpGet]
        [Route("All/{id}")]
        public async Task<ActionResult> Get(string id , string test)
        {
            var result = await this.resourceService.GetAllByLectureIdAsync<ResourceViewModel>(id);

            return this.GenericResponse(new ResultModel(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var result = await this.resourceService.GetByIdAsync<ResourceViewModel>(id);

            return this.GenericResponse(new ResultModel(result));
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateResourceInputModel resourceModel)
        {
            var result = await this.resourceService.CreateAsync(resourceModel);

            return this.GenericResponse(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put(EditResourceServiceModel resourceModel)
        {
            var result = await this.resourceService.EditAsync(resourceModel);

            return this.GenericResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var result = await this.resourceService.DeleteByIdAsync(id);

            return this.GenericResponse(result);
        }
    }
}