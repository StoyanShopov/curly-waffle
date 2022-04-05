namespace SBC.Web.Areas.Employee.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Resources;
    using SBC.Web.ViewModels.Administration.Resources;

    public class ResourcesController : EmployeesBaseController
    {
        private readonly IResourcesService resourceService;

        public ResourcesController(IResourcesService resourceService)
        {
            this.resourceService = resourceService;
        }

        [HttpGet]
        [Route("All/{id}")]
        public async Task<ActionResult> Get(string id, string test)
        {
            var result = await this.resourceService.GetAllByLectureIdAsync<ResourceViewModel>(id);

            return this.GenericResponse(result);
        }
    }
}
