using System;

namespace Project1.Common.Events.UserAdded
{
    public interface IUserDemoted
    {
        Guid UserId { get; }
    }
}