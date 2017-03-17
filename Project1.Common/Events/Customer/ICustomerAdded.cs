using System;
using Project1.Common.Enums;

namespace Project1.Common.Events.Customer
{
    public interface ICustomerAdded : IEvent
    {
        Guid Id { get; }
        string Name { get; }
        CustomerStatus Status { get; }
    }
}