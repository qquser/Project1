using System;
using Project1.Common.Enums;
using Project1.Common.Events.Customer;

namespace Project1.Domain.Customer.Events
{
    internal class CustomerAdded : ICustomerAdded
    {
        public CustomerAdded(Guid id, string name, CustomerStatus status)
        {
            Id = id;
            Name = name;
            Status = status;
        }

        public Guid Id { get; }
        public string Name { get; }
        public CustomerStatus Status { get; }
    }
}