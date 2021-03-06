namespace SBC.Web.Areas.Employee.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Data.Coaches;
    using SBC.Services.Data.Infrastructures;
    using SBC.Services.Data.Users;
    using SBC.Web.ViewModels.Employees.Feedback;

    public class CoachesController : EmployeesBaseController
    {
        private readonly ICoachesService coachesService;
        private readonly IUsersService usersService;

        public CoachesController(ICoachesService coachesService, IUsersService usersService)
        {
            this.coachesService = coachesService;
            this.usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] string search)
        {
            int companyId = this.usersService
                 .GetCompanyId(this.User.Id());

            var result = await this.coachesService
                .GetAllOfEmployeeAsync(companyId, this.User.Id(), search);

            return this.GenericResponse(result);
        }

        [HttpPost("book-coach/{coachId}")]
        public async Task<ActionResult> Book(int coachId)
        {
            var result = await this.coachesService
                 .BookCoachAsync(this.User.Id(), coachId);

            return this.GenericResponse(result);
        }

        [HttpPost("left-feadback")]
        public async Task<ActionResult> LeftFeedback(FeedbackInputModel feedback)
        {
            var user = await this.usersService
                 .GetUserAsync(this.User.Id());

            var result = await this.coachesService
                .LeftFeedbackAsync(user, feedback);

            return this.GenericResponse(result);
        }
    }
}
