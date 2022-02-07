namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Client.Contracts;
    using SBC.Web.Areas.Administration.Models.Client;

    public class ClientController : AdministrationController
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        [Route(nameof(GetPortion))]
        public async Task<ActionResult> GetPortion(int skip)
            => this.GenericResponse(await this.clientService.GetPortionAsync(skip));

        [HttpPost]
        [Route(nameof(Add))]
        public async Task<ActionResult> Add(AddRequestModel model)
            => this.GenericResponse(await this.clientService.AddAsync(model.FullName, model.Email));
    }
}
