using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ExploreCalifornia
{
    public class SimpleHub : Hub
    {
        public void Hello()
        {
            Clients.All.introduce("Welcome, it is a SignalR Hub.");
        }
    }
}