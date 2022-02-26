namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Client;
    using SBC.Web.ViewModels.Administration.Client;

    public class ClientsController : AdministrationController
    {
        private readonly IClientService clientService;

        public ClientsController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        [Route(nameof(Portion))]
        public async Task<ActionResult> Portion(int skip)
            => this.GenericResponse(await this.clientService.GetPortionAsync(skip));

        [HttpPost]
        public async Task<ActionResult> Add(CreateClientInputModel model)
            => this.GenericResponse(await this.clientService.AddAsync(model));
    }
}
