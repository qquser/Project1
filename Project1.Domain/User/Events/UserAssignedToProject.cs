using System;
using Project1.Common.Events.UserAdded;

namespace Project1.Domain.User.Events
{
    internal class UserAssignedToProject : IUserAssignedToProject
    {
        public UserAssignedToProject(Guid userId, Guid projectId)
        {
            UserId = userId;
            ProjectId = projectId;
        }

        public Guid UserId { get; }
        public Guid ProjectId { get; }
    }
}