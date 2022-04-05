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
        public async Task<ActionResult> Get()
        {
            var result = await this.usersService
                .GetUserDataAsync<ProfileViewModel>(this.User.Id());

            return this.GenericResponse(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(EditProfileInputModel model)
        {
            var result = await this.usersService
                .UpdateAsync(model, this.User.Id());

            return this.GenericResponse(result);
        }
    }
}
