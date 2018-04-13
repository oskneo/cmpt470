using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;


    public class LiveHelpHub : Hub
    {      
        public async Task Send(string name, string message)
        {
            await Clients.All.InvokeAsync("Send", name, message);
        }
    }
