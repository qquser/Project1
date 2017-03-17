using System;

namespace Project1.Common.Commands.Customer
{
    public interface IMakeCustomerInActive : ICommand
    {
        Guid Id { get; }
    }
}