namespace SBC.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Category.Contracts;
    using SBC.Services.Data.Category.Models;

    using static SBC.Common.GlobalConstants.ControllerRouteConstants;

    public class CategoriesController : ApiController
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet(GetAllRoute)]
        public async Task<ActionResult<List<ListingCategoryModel>>> GetAllCategoriesAsync()
        {
            return await this.categoryService.GetAll();
        }
    }
}
