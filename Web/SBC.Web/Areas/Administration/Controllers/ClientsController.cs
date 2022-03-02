namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Clients;
    using SBC.Web.ViewModels.Administration.Client;

    public class ClientsController : AdministrationController
    {
        private readonly IClientsService clientsService;

        public ClientsController(IClientsService clientService)
        {
            this.clientsService = clientService;
        }

        [HttpGet]
        [Route(nameof(Portion))]
        public async Task<ActionResult> Portion(int skip)
        {
            var result = await this.clientsService.GetPortionAsync(skip);

            return this.GenericResponse(result);
        }

        [HttpPost]
        public async Task<ActionResult> Add(CreateClientInputModel model)
        {
            var result = await this.clientsService.AddAsync(model);

            return this.GenericResponse(result);
        }
    }
}
