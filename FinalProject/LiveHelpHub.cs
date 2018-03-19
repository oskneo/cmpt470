using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ExploreCalifornia
{
    public class LiveHelpHub : Hub
    {
        public async Task SendMessage(string message)
        {
            //Clients.All.InvokeAsync(username, message);
            //Clients.All.InvokeAsync("broadcastMessage", username, message);
            //Groups.Add(Context.ConnectionId, "Employees");
            //Clients.Group("Employee").showMessage(username, "This is a message for the Employees group.");
            
            //Clients.Caller.showMessage("system", "Your message was sent at " + DateTime.Now.ToString("h:mm tt"));
            
            
            await Clients.All.InvokeAsync("Send", message);

        }
    }
}