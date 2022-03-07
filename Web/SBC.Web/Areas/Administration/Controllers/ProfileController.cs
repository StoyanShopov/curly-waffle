namespace SBC.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using SBC.Services.Data.Infrastructures;
    using SBC.Services.Data.Users;
    using SBC.Web.ViewModels.User;

    public class ProfileController : AdministrationController
    {
        private readonly IUsersService usersService;

        public ProfileController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await this.usersService
                .GetUserDataAsync<ProfileViewModel>(this.User.Id());

            return this.GenericResponse(result);
        }

        [HttpPut]
        public async Task<ActionResult> EditAsync(EditProfileInputModel model)
        {
            var result = await this.usersService.EditAsync(model, this.User.Id());

            return this.GenericResponse(result);
        }
    }
}
