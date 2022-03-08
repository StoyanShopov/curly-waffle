namespace SBC.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using SBC.Services.Data.Language;
    using SBC.Web.ViewModels.Language;

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
