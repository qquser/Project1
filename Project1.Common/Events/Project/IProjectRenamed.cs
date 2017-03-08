using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Common.Events.Project
{
    public interface IProjectRenamed : IEvent
    {
        Guid Id { get; }
        string NewName { get; }
        string OldName { get; }
    }
}
