namespace SBC.Web.Controllers
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using SBC.Web.Infrastructures.Hub;

    public class MessageController : ApiController
    {
        private readonly IHubContext<NotificationHub> messageHub;

        public MessageController([NotNull] IHubContext<NotificationHub> messageHub)
        {
            this.messageHub = messageHub;
        }

        [HttpPost]
        public async Task<IActionResult> Create(NotifyMessage messagePost)
        {
            await this.messageHub.Clients.All.SendAsync("sendToReact", "The message '" + messagePost.Message + "' has been received");

            return this.Ok();
        }
    }
}
