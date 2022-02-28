namespace SBC.Web.Areas.BusinessOwner.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Profile;
    using SBC.Web.ViewModels.BusinessOwner.Profile;

    public class BusinessOwnerProfileController : BusinessOwnerController
    {
        private readonly IBusinessOwnerProfileService businessOwnerProfileService;

        public BusinessOwnerProfileController(IBusinessOwnerProfileService businessOwnerProfileService)
        {
            this.businessOwnerProfileService = businessOwnerProfileService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync(string userId)
            => this.GenericResponse(await this.businessOwnerProfileService.GetBusinessOwnerDataAsync(userId));

        [HttpPut]
        public async Task<ActionResult> EditAsync(EditProfileServiceModel model, string userId)
            => this.GenericResponse(await this.businessOwnerProfileService.EditAsync(model, userId));
    }
}
