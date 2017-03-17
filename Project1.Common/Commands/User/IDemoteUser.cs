using System;

namespace Project1.Common.Commands.User
{
    public interface IDemoteUser : ICommand
    {
        Guid UserId { get; }
    }
}