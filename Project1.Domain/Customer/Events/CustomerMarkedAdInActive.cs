using System;
using Project1.Common.Events.Customer;

namespace Project1.Domain.Customer.Events
{
    internal class CustomerMarkedAsInActive : ICustomerMarkedAsInActive
    {
        public CustomerMarkedAsInActive(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}