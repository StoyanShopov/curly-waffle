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
        public async Task<IActionResult> Create(NotifyMessage messagePost, string groupName)
        {
            await this.messageHub.Clients.Group(groupName).SendAsync("sendToReact", "The message '" + messagePost.Message + "' has been received");

            return this.Ok();
        }
    }
}
