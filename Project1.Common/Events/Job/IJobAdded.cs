using Project1.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Common.Events.Job
{
    public interface IJobAdded : IEvent
    {
        Guid Id { get; }
        string Name { get; }
        Guid WorkshopId { get; }
        Guid UserId { get; }
        JobStatus Status { get; }
    }
}
