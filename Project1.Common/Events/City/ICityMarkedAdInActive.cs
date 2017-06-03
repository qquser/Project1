using System;

namespace Project1.Common.Events.City
{
    public interface ICityMarkedAsInActive : IEvent
    {
        Guid Id { get; }
    }
}