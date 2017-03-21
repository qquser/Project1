using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Common.Commands.Customer;
using Topshelf.Logging;
using Project1.Common.Events.Customer;
using Microsoft.AspNet.SignalR.Client;

namespace Project1.Informer.MessegeServices.Customer
{
    public class CustomerMessageService : ICustomerMessageService
    {
        private readonly IHubProxy _hub;
        public CustomerMessageService(IHubProxy hub)
        {
            _hub = hub;
        }
 
        public void SendInfoCustomerAdded(ICustomerAdded model)
        {
            _hub.Invoke("DetermineLength", "Customer with name: "+ model.Name + "  was added!");
        }
    }
}
