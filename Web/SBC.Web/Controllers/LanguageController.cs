namespace SBC.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Common;
    using SBC.Services.Data.Language.Contracts;
    using SBC.Web.ViewModels.Language;

    using static SBC.Common.GlobalConstants.ControllerRouteConstants;

    public class LanguageController : ApiController
    {
        private readonly ILanguageService languageService;

        public LanguageController(ILanguageService languageService)
        {
            this.languageService = languageService;
        }

        [HttpGet("Languages")]
        public async Task<ActionResult> GetAllCategoriesAsync()
        {
            var result = await this.languageService.GetAllAsync<ListingLanguageModel>();

            return this.GenericResponse(new ResultModel(result));
        }
    }
}
