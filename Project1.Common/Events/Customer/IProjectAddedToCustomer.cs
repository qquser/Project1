using System;

namespace Project1.Common.Events.Customer
{
    public interface IProjectAddedToCustomer : IEvent
    {
        Guid ProjectId { get; }
        Guid CustomerId { get; }
    }
}