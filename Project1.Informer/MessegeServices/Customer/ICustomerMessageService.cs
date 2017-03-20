using Project1.Common.Commands.Customer;
using Project1.Common.Events.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Informer.MessegeServices.Customer
{
    public interface ICustomerMessageService : IMessageService
    {
        void SendInfoCustomerAdded(ICustomerAdded model);
    }
}
