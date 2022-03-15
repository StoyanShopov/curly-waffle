namespace SBC.Web.Infrastructures.Hub
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.SignalR;

    public class NotificationHub : Hub
    {
        public async Task SendMessage(NotifyMessage message)
        {
            await this.Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
