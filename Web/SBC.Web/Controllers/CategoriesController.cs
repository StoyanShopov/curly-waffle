namespace SBC.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Categories;
    using SBC.Web.ViewModels.Categories;

    public class CategoriesController : ApiController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoryService)
        {
            this.categoriesService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var result = await this.categoriesService.GetAllAsync<CategoryDetailsViewModel>();

            return this.GenericResponse(result);
        }

        [HttpGet("{coachId}")]
        public async Task<ActionResult> GetByCoachIdAsync(int coachId)
        {
            var result = await this.categoriesService.GetByCoachIdAsync(coachId);

            return this.GenericResponse(result);
        }
    }
}
