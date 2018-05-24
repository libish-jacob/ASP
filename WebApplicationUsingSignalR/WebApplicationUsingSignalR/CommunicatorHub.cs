using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Linq;

namespace WebApplicationUsingSignalR
{
    [HubName("CommunicatorHub")]
    public class CommunicatorHub : Hub
    {
        public void Send(string name, string message)
        {

            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }
    }
}