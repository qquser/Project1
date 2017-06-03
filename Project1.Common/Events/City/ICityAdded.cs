using System;
using Project1.Common.Enums;

namespace Project1.Common.Events.City
{
    public interface ICityAdded : IEvent
    {
        Guid Id { get; }
        string Name { get; }
        CityStatus Status { get; }
    }
}