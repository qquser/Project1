using System;

namespace Project1.Common.Commands.User
{
    public interface IAssignUserToProject : ICommand
    {
        Guid UserId { get; }
        Guid ProjectId { get; }
    }
}