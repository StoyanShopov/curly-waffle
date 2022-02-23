namespace SBC.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Common;
    using SBC.Services.Data.Language;
    using SBC.Web.ViewModels.Language;

    using static SBC.Common.GlobalConstants.ControllerRouteConstants;

    public class LanguagesController : ApiController
    {
        private readonly ILanguageService languageService;

        public LanguagesController(ILanguageService languageService)
        {
            this.languageService = languageService;
        }

        [HttpGet(nameof(GetAllLanguagesAsync))]
        public async Task<ActionResult> GetAllLanguagesAsync()
        {
            var result = await this.languageService.GetAllAsync<ListingLanguageViewModel>();

            return this.GenericResponse(new ResultModel(result));
        }
    }
}
