namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Companies;
    using SBC.Web.ViewModels.Administration.Company;

    public class CompaniesController : AdministrationController
    {
        private readonly ICompaniesService companyService;

        public CompaniesController(ICompaniesService clientService)
        {
            this.companyService = clientService;
        }

        [HttpPost]
        public async Task<ActionResult> Add(CreateCompanyInputModel model)
        {
            var result = await this.companyService.AddAsync(model);

            return this.GenericResponse(result);
        }
    }
}
