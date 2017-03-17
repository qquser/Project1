using System;

namespace Project1.Common.Events.UserAdded
{
    public interface IUserPromoted
    {
        Guid UserId { get; }
    }
}