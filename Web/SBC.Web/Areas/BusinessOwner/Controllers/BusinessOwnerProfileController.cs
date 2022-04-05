namespace SBC.Web.Areas.BusinessOwner.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Infrastructures;
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
        public async Task<ActionResult> GetAsync()
            => this.GenericResponse(await this.usersService.GetUserDataAsync<ProfileViewModel>(this.User.Id()));

        [HttpPut]
        public async Task<ActionResult> EditAsync(EditProfileInputModel model)
            => this.GenericResponse(await this.usersService.UpdateAsync(model, this.User.Id()));
    }
}
