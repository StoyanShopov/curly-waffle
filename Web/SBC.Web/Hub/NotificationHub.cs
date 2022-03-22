namespace SBC.Web.Infrastructures.Hub
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.SignalR;
    using SBC.Services.Data.Users;
    using SBC.Web.ViewModels.User;

    public class NotificationHub : Hub
    {
        private readonly IDictionary<string, UserConnection> connections;
        private readonly IUsersService usersService;

        public NotificationHub(
            IDictionary<string, UserConnection> connections,
            IUsersService usersService)
        {
            this.connections = connections;
            this.usersService = usersService;
        }

        public async Task JoinGroupAsync([NotNull] string email)
        {
            var userConnection = await this.usersService.GetByEmailAsync<UserConnection>(email);

            await this.Groups.AddToGroupAsync(this.Context.ConnectionId, userConnection.CompanyName);

            this.connections.Add(this.Context.ConnectionId, userConnection);
        }

        public async Task SendNotifyMessage([NotNull] string notifyMessage)
        {
            if (this.connections
                .TryGetValue(this.Context.ConnectionId, out UserConnection user))
            {
                await this.Clients
                    .Group(user.CompanyName)
                    .SendAsync("Notify", notifyMessage);
            }
        }
    }
}
