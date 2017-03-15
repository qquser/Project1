using System;
using System.Threading.Tasks;
using Project1.Common.Events;
using MassTransit;
using Ninject;
using System.Threading;

namespace Project1.WriteSide
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IBusControl _bus;

        public EventPublisher(IBusControl bus)
        {
            _bus = bus;// container.Get<IBusControl>();
        }

        public async Task PublishAsync(dynamic e)
        {
            var address = "rabbitmq://localhost/events";
            var endpoint = await _bus.GetSendEndpoint(new Uri(address));
            await endpoint.Send(e);
        }

        //    public async Task PublishAsync<TMessage>(TMessage message,
        //CancellationToken cancellationToken = default(CancellationToken))
        //where TMessage : class
        //    {
        //        var address = "rabbitmq://localhost/events";
        //        var endpoint = await _bus.GetSendEndpoint(new Uri(address));
        //        await endpoint.Send<TMessage>(message, cancellationToken);
        //    }

    }
}