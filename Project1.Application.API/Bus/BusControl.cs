using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project1.Application.API.Bus
{
    public class BusControl
    {
        public static async Task Send<TMessage>(TMessage message, CancellationToken cancellationToken = default(CancellationToken))
             where TMessage : class
        {
            var address = "rabbitmq://localhost/commands";
            var endpoint = await Startup.Bus.GetSendEndpoint(new Uri(address));
            await endpoint.Send(message, cancellationToken);
        }

        public static async Task<TResponse> SendRequest<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default(CancellationToken))
             where TRequest : class
             where TResponse : class
        {
            var address = new Uri("rabbitmq://localhost/requests");
            var requestTimeout = TimeSpan.FromSeconds(30);

            IRequestClient<TRequest, TResponse> client =
                new MessageRequestClient<TRequest, TResponse>(Startup.Bus, address, requestTimeout);
            return await client.Request(request, cancellationToken);
        }

        public static async Task<TResponse> SendCommandWithRespond<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default(CancellationToken))
              where TRequest : class
              where TResponse : class
        {
            var address = new Uri("rabbitmq://localhost/commands");
            var requestTimeout = TimeSpan.FromSeconds(30);

            IRequestClient<TRequest, TResponse> client =
                new MessageRequestClient<TRequest, TResponse>(Startup.Bus, address, requestTimeout);
            return await client.Request(request, cancellationToken);
        }
    }
}
