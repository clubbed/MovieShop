using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace MovieShop.signalr.hubs
{
    public class ChatHub : Hub
    {
        public override System.Threading.Tasks.Task OnConnected()
        {
            Clients.All.user(Context.User.Identity.Name);
            return base.OnConnected();
        }

        public void send(string message)
        {
            Clients.Caller.message("You~You: " + message);
            Clients.Others.message("others~" + Context.User.Identity.Name + ": " + message);
        }
    }
}