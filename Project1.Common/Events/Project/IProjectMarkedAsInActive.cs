using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Common.Events.Project
{
    public interface IProjectMarkedAsInActive : IEvent
    {
        Guid Id { get; }
    }
}
