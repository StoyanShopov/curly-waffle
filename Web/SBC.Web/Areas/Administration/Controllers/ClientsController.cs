namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Common;
    using SBC.Services.Data.User.Contracts;
    using SBC.Web.Areas.Administration.Models.Client;

    public class ClientsController : AdministrationController
    {
        private readonly IUserService userService;

        public ClientsController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route(nameof(GetPortion))]
        public async Task<Result> GetPortion(int skip)
            => await this.userService.GetPortionAsync(skip);

        [HttpPost]
        [Route(nameof(Add))]
        public async Task<Result> Add(AddRequestModel model)
        {

        }
    }
}
