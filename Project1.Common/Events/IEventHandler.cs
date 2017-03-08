using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Common.Events
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent e);
    }
}
