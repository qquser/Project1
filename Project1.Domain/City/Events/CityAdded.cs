using System;
using Project1.Common.Enums;
using Project1.Common.Events.Customer;
using Project1.Common.Events.City;

namespace Project1.Domain.City.Events
{
    internal class CityAdded : ICityAdded
    {
        public CityAdded(Guid id, string name, CityStatus status)
        {
            Id = id;
            Name = name;
            Status = status;
        }

        public Guid Id { get; }
        public string Name { get; }
        public CityStatus Status { get; }
    }
}