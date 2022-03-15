namespace SBC.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    public class MessageController : ApiController
    {
        public MessageController()
        {
        }

        [Route(nameof(Message))]
        public async Task<ActionResult> Message()
        {
            return null;
        }
    }
}
