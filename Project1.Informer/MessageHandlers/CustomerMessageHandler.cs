using MassTransit;
using Project1.Common.Commands.Customer;
using Project1.Common.Events.Customer;
using Project1.Informer.MessegeServices;
using Project1.Informer.MessegeServices.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Informer.MessageHandlers
{
    public class CustomerMessageHandler :
        IConsumer<ICustomerAdded>
    {
        private readonly ICustomerMessageService _service;
        public CustomerMessageHandler(ICustomerMessageService service)
        {
            _service = service;
        }

        public async Task Consume(ConsumeContext<ICustomerAdded> context)
        {
            await Task.Run(() => _service.SendInfoCustomerAdded(context.Message));
        }
    }
}
