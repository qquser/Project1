using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Hubs
{
    [HubName("TestHub")]
    public class TestHub : Hub
    {
        public void DetermineLength(string message)
        {
            Clients.All.ReceiveLength(message);
        }
    }
}
