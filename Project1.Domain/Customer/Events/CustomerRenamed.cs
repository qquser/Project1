using System;
using Project1.Common.Events.Customer;

namespace Project1.Domain.Customer.Events
{
    internal class CustomerRenamed : ICustomerRenamed
    {
        public CustomerRenamed(Guid id, string newName, string oldName)
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