using System;
using Project1.Common.Events.UserAdded;

namespace Project1.Domain.User.Events
{
    internal class UserPromoted : IUserPromoted
    {
        public UserPromoted(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}