SignalR implementation in AS.Net 5


Implementation of the toutorial https://docs.microsoft.com/en-us/aspnet/signalr/overview/getting-started/tutorial-getting-started-with-signalr

Add nuget package Microsoft.Owin.Host.SystemWeb
Add new item -> owin startup page.
map signalr in startup class

Add SignalR package(Microsoft.AspNet.SignalR). Make sure that the script for SignalR is available in scripts folder.

create hub class by inheriting from Hub class defined by SignalR

make sure that the html cshtml is refering to the actual SignalR and JQuery script files. Make sure the name is correct.

make sure that you get hold of the hub proxy (var chat = $.connection.CommunicatorHub;) in your page.
There are two ways of doing it. By default signalR script expects camel case hub name.
1. Make sure that you have specified the hub name in script using camel casing even if you have defined the actual class in other case.
If you dont like this then use case2
2. Specify HubName attribute on your hub class as mentioned below. By doing this, the signalR script will read the hub name as what is specified in the attribute
	[HubName("CommunicatorHub")]
	public class CommunicatorHub : Hub
	{}
Get help of debugger if you are not sure of what to do and get hold of the hub name available at script side. inspect $.connection

Make sure the edited file is the one running. Rebuild the project to make sure it is the case. This may be required when you are editing the javascript.

People say we have to change the script to point to the path by using <script src="~/signalr/hubs"></script>. But I have used only <script src="signalr/hubs"></script>


Register methods which needs to be called by server. Here broadcastMessage is the name of the method.
chat.client.broadcastMessage = function (name, message) {}

And at server side, call this method by using Clients.All.broadcastMessage(name, message); It is dynamic.


TODO: Implement a chat app where user can do group aswell as individual chat.



