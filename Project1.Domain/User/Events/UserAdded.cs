using System;
using Project1.Common.Enums;
using Project1.Common.Events.UserAdded;

namespace Project1.Domain.User.Events
{
    internal class UserAdded : IUserAdded
    {
        public UserAdded(Guid id, string firstName, string lastName, UserRole role)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public UserRole Role { get; }
    }
}