using System;
using Project1.Common.Events.Customer;

namespace Project1.Domain.Customer.Events
{
    internal class ProjectAddedToCustomer : IProjectAddedToCustomer
    {
        public ProjectAddedToCustomer(Guid projectId, Guid customerId)
        {
            ProjectId = projectId;
            CustomerId = customerId;
        }

        public Guid ProjectId { get; }
        public Guid CustomerId { get; }
    }
}