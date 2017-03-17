using System.Collections.Generic;
using Project1.Common;
using Project1.Common.Enums;

namespace Project1.Domain.Customer.ValueObjects
{
    internal class CustomerState
    {
        public NonEmptyIdentity Id { get; set; }
        public CustomerStatus Status { get; set; }
        public CustomerName Name { get; set; }
        public List<NonEmptyIdentity> ProjectIds { get; set; } = new List<NonEmptyIdentity>();
    }
}