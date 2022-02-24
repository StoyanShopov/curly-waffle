namespace SBC.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Common;
    using SBC.Services.Data.Category;
    using SBC.Web.ViewModels.Category;

    using static SBC.Common.GlobalConstants.ControllerRouteConstants;

    public class CategoriesController : ApiController
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet(nameof(GetAllCategoriesAsync))]
        public async Task<ActionResult> GetAllCategoriesAsync()
        {
            var result = await this.categoryService.GetAllAsync<CategoryDetailsViewModel>();

            return this.GenericResponse(new ResultModel(result));
        }
    }
}
