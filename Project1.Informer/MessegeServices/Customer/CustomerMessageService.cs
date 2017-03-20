using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Common.Commands.Customer;
using Topshelf.Logging;
using Project1.Common.Events.Customer;

namespace Project1.Informer.MessegeServices.Customer
{
    public class CustomerMessageService : ICustomerMessageService
    {
        private readonly LogWriter _logger = HostLogger.Get<InformerService>();

        public void SendInfoCustomerAdded(ICustomerAdded model)
        {
            _logger.Info("!!");
        }
    }
}
