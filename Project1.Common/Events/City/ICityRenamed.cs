using System;

namespace Project1.Common.Events.City
{
    public interface ICityRenamed : IEvent
    {
        Guid Id { get; }
        string NewName { get; }
        string OldName { get; }
    }
}