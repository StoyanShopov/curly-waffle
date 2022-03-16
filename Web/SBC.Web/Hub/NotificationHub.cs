namespace SBC.Web.Infrastructures.Hub
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.SignalR;
    using SBC.Services.Data.Companies;

    public class NotificationHub : Hub
    {
        private readonly ICompaniesService companiesService;

        public NotificationHub(ICompaniesService companiesService)
        {
            this.companiesService = companiesService;
        }

        public async Task SendMessage(NotifyMessage message)
        {
            await this.Clients.All.SendAsync("ReceiveMessage", message);
        }

        public Task JoinGroupAsync(string groupName)
        {
            return this.Groups.AddToGroupAsync(this.Context.ConnectionId, groupName);
        }

        public Task RemoveGroupAsync(string groupName)
        {
            return this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, groupName);
        }

        public override Task OnConnectedAsync()
        {
            string userName = this.Context.User.Identity.Name;

            //TODO: write logic

            return this.OnConnectedAsync();
        }

    }
}
