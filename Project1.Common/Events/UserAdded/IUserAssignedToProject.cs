using System;

namespace Project1.Common.Events.UserAdded
{
    public interface IUserAssignedToProject
    {
        Guid UserId { get; }
        Guid ProjectId { get; }
    }
}