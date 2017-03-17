using System;

namespace Project1.Common.Events.Customer
{
    public interface ICustomerMarkedAsInActive : IEvent
    {
        Guid Id { get; }
    }
}