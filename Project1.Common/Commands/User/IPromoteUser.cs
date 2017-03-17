using System;

namespace Project1.Common.Commands.User
{
    public interface IPromoteUser : ICommand
    {
        Guid UserId { get; }
    }
}