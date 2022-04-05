namespace SBC.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Companies;
    using SBC.Web.ViewModels.Company;

    public class CompaniesController : ApiController
    {
        private readonly ICompaniesService companiesService;

        public CompaniesController(ICompaniesService companiesService)
        {
            this.companiesService = companiesService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCompanies()
        {
            var result = await this.companiesService.GetAllAsync<CompanyViewModel>();

            return this.GenericResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmailById(int id)
        {
            var result = await this.companiesService.GetEmailByIdAsync(id);

            return this.GenericResponse(result);
        }
    }
}
