using System;
using Project1.Common.Events.Customer;
using Project1.Common.Events.City;

namespace Project1.Domain.City.Events
{
    internal class CityMarkedAsInActive : ICityMarkedAsInActive
    {
        public CityMarkedAsInActive(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}