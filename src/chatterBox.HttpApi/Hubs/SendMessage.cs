using chatterBox.Mapping;
using chatterBox.Messages;
using Microsoft.AspNetCore.SignalR;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.SignalR;
using Volo.Abp.Users;

namespace chatterBox.Hubs
{
    [HubRoute("/hub")]
    public class SendMessage :AbpHub
    {
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();


        public async Task NewMessage(MessageInfo message)
        {
            string recipientID = Convert.ToString(message.ReceiverId);
            var connectionIds = _connections.GetConnections(recipientID);

            foreach (var connectionId in connectionIds)
            {
                await Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
            }
        }
        public async Task EditMessage(MessageInfo message)
        {
            string recipientID = Convert.ToString(message.ReceiverId);
            var connectionIds = _connections.GetConnections(recipientID);

            foreach (var connectionId in connectionIds)
            {
                await Clients.Client(connectionId).SendAsync("ReceiveEditMessage", message);
            }
        }

        public async Task DeleteMessage(MessageInfo message)
        {
            
            string recipientID = Convert.ToString(message.ReceiverId);
            var connectionIds = _connections.GetConnections(recipientID);

            foreach (var connectionId in connectionIds)
            {
                await Clients.Client(connectionId).SendAsync("ReceiveDeleteMessage", message);
            }
        }
        public override Task OnConnectedAsync()
        {

            string userId = Convert.ToString(CurrentUser.GetId());
            _connections.Add(userId, Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            string userId = Convert.ToString(CurrentUser.GetId());
            _connections.Remove(userId, Context.ConnectionId);

            return base.OnDisconnectedAsync(exception);
        }
    }
}
