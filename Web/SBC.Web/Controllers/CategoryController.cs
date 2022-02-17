namespace SBC.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Common;
    using SBC.Services.Data.Category.Contracts;
    using SBC.Web.ViewModels.Category;
    using static SBC.Common.GlobalConstants.ControllerRouteConstants;

    public class CategoryController : ApiController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("Categories")]
        public async Task<ActionResult> GetAllCategoriesAsync()
        {
            var result = await this.categoryService.GetAllAsync<ListingCategoryModel>();

            return this.GenericResponse(new ResultModel(result));
        }
    }
}
