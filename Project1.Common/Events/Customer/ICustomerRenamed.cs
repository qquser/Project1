using System;

namespace Project1.Common.Events.Customer
{
    public interface ICustomerRenamed : IEvent
    {
        Guid Id { get; }
        string NewName { get; }
        string OldName { get; }
    }
}