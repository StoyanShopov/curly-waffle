namespace SBC.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Language.Contracts;
    using SBC.Services.Data.Language.Models;

    using static SBC.Common.GlobalConstants.ControllerRouteConstants;

    public class LanguagesController : ApiController
    {
        private readonly ILanguageService languageService;

        public LanguagesController(ILanguageService coachService)
        {
            this.languageService = coachService;
        }

        [HttpGet(GetAllRoute)]
        public async Task<ActionResult<List<ListingLanguageModel>>> GetAllLanguagesAsync()
        {
            return await this.languageService.GetAll();
        }
    }
}
