using MassTransit;
using Project1.Common.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.ReadSide.Updaters
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly IBusControl _bus;

        public MessagePublisher(IBusControl bus)
        {
            _bus = bus;
        }

        public async Task PublishMessageAsync(dynamic e)
        {
            var address = "rabbitmq://localhost/messages";
            var endpoint = await _bus.GetSendEndpoint(new Uri(address));
            await endpoint.Send(e);
        }
    }
}
