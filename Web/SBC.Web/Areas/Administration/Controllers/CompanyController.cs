namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Company.Contracts;
    using SBC.Web.Areas.Administration.Models.Company;

    public class CompanyController : AdministrationController
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService clientService)
        {
            this.companyService = clientService;
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddCompanyRequestModel model)
            => this.GenericResponse(await this.companyService.Add(model.Name, model.Email, model.LogoUrl));
    }
}
