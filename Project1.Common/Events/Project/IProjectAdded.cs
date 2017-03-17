using System;
using System.Collections.Generic;
using System.Text;
using Project1.Common.Enums;

namespace Project1.Common.Events.Project
{
    public interface IProjectAdded : IEvent
    {
        Guid Id { get; }
        string Name { get; }
        Guid CustomerId { get; }
        ProjectStatus Status { get; }
    }
}
