namespace SBC.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using SBC.Services.Data.Languages;
    using SBC.Web.ViewModels.Languages;

    public class LanguagesController : ApiController
    {
        private readonly ILanguagesService languagesService;

        public LanguagesController(ILanguagesService languageService)
        {
            this.languagesService = languageService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var result = await this.languagesService.GetAllAsync<LanguageDetailsViewModel>();

            return this.GenericResponse(result);
        }
    }
}
