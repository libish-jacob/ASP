using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApplicationUsingSignalR
{
    [HubName("CommunicatorHub")]
    public class CommunicatorHub : Hub
    {
        private static IDictionary<string, string> users = new Dictionary<string, string>();

        public override Task OnConnected()
        {
            var name = Context.User.Identity.Name;
            if (string.IsNullOrEmpty(name))
            {
                name = "Anonymous" + Guid.NewGuid();
            }
            
            var connectionId = Context.ConnectionId;
            
            users.Add(name, connectionId);

            Clients.Client(connectionId).ConnectedUserGeneratedName(name);

            Clients.All.onlineUsers(users.Keys.ToArray());
            
            return Task.FromResult("");
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var name = Context.User.Identity.Name;
            if (users.ContainsKey(name))
            {
                users.Remove(name);
            }

            Clients.All.onlineUsers(users.Keys.ToArray());
            return Task.FromResult("");
        }

        public void Send(string name, string message)
        {   
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
            
        }

        public void SendPersonal(string fromName, string toName, string message)
        {   
            Clients.Client(users[toName]).personalMessage(fromName, message);
            Clients.Client(users[fromName]).personalMessage(toName, message);
        }
        
    }
}