using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project1.Common.Events
{
    public interface IEventPublisher
    {
        Task PublishAsync<TMessage>(TMessage e, CancellationToken cancellationToken) where TMessage : class;
    }
}
