using System;
using Project1.Common.Events.Customer;
using Project1.Common.Events.City;

namespace Project1.Domain.City.Events
{
    internal class CityRenamed : ICityRenamed
    {
        public CityRenamed(Guid id, string newName, string oldName)
        {
            Id = id;
            NewName = newName;
            OldName = oldName;
        }

        public Guid Id { get; }
        public string NewName { get; }
        public string OldName { get; }
    }
}