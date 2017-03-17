using System;
using Project1.Common;

namespace Project1.Domain.Customer.ValueObjects
{
    internal class CustomerName : ValueObject<string>
    {
        public CustomerName(string name) : base(name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(nameof(name));
            }
        }
    }
}
