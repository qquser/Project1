using System;

namespace Project1.Common.Commands.Customer
{
    public interface IRenameCustomer : ICommand
    {
        Guid Id { get; }

        string NewName { get; }
    }
}