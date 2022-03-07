namespace SBC.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using SBC.Common;
    using SBC.Services.Data.Category;
    using SBC.Web.ViewModels.Category;

    public class CategoriesController : ApiController
    {
        private readonly ICategoriesService categoryService;

        public CategoriesController(ICategoriesService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var result = await this.categoryService.GetAllAsync<CategoryDetailsViewModel>();

            return this.GenericResponse(new ResultModel(result));
        }
    }
}
