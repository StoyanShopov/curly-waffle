using Microsoft.AspNetCore.Mvc;
using SBC.Data.Common.Models;
using SBC.Data.Common.Repositories;
using SBC.Data.Models;
using SBC.Services.Data.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBC.Web.Controllers
{
    public class CompaniesController : ApiController
    {
        private readonly ICompaniesService companiesService;

        public CompaniesController(ICompaniesService companiesService)
        {
            this.companiesService = companiesService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmailByIdAsync(int id)
        {
            var result = await this.companiesService.GetEmailByIdAsync(id);
            return this.GenericResponse(result);
        }
    }
}
