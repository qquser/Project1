using System;

namespace Project1.Common.Commands.Customer
{
    public interface IAddCustomer : ICommand
    {
        Guid Id { get; }

        string Name { get; }
    }
}