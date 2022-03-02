namespace SBC.Web.Areas.BusinessOwner.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Users;
    using SBC.Web.ViewModels.User;

    public class BusinessOwnerProfileController : BusinessOwnerController
    {
        private readonly IUsersService usersService;

        public BusinessOwnerProfileController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync(string userId)
            => this.GenericResponse(await this.usersService.GetAdminDataAsync<ProfileViewModel>(userId));

        [HttpPut]
        public async Task<ActionResult> EditAsync(EditProfileInputModel model, string userId)
            => this.GenericResponse(await this.usersService.EditAsync(model, userId));
    }
}
