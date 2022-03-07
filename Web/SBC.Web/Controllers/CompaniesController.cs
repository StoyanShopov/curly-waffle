namespace SBC.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Company;
    using SBC.Web.ViewModels.Companies;

    public class CompaniesController : ApiController
    {
        private readonly ICompaniesService companiesService;

        public CompaniesController(ICompaniesService companiesService)
        {
            this.companiesService = companiesService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCompaniesAsync()
        {
            var result = await this.companiesService.GetAllAsync<CompanyViewModel>();
            return this.GenericResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmailByIdAsync(int id)
        {
            var result = await this.companiesService.GetEmailByIdAsync(id);
            return this.GenericResponse(result);
        }
    }
}
