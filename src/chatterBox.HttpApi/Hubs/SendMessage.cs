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


        //private readonly ConnectionMapping<string> _connections;

        //public SendMessage(ConnectionMapping<string> connections)
        //{
        //    _connections = connections;
        //}
        //?? throw new ArgumentNullException(nameof(connections))
        public async Task NewMessage(MessageInfo message)
        {
            // Get the recipient's name from the message (assuming the recipient name is in the 'to' property).
            string recipientID = Convert.ToString(message.ReceiverId);

            // Get the connection IDs associated with the recipient's name.
            var connectionIds = _connections.GetConnections(recipientID);

            // Send the message to each of the recipient's connections.
            foreach (var connectionId in connectionIds)
            {
                await Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
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
