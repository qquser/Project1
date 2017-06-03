using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Common.Events.Job
{
    public interface IJobMarkedAsInActive : IEvent
    {
        Guid Id { get; }
    }
}
