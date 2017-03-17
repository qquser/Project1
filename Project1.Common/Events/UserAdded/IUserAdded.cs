using System;
using Project1.Common.Enums;

namespace Project1.Common.Events.UserAdded
{
    public interface IUserAdded
    {
        Guid Id { get; }
        string FirstName { get; }
        string LastName { get; }
        UserRole Role { get; }
    }
}