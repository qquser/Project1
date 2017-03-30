using System;
using Project1.Common.Enums;
using Project1.Common.Events.UserAdded;

namespace Project1.Domain.User.Events
{
    internal class UserRegistred : IUserRegistred
    {
        public UserRegistred(Guid id, string email, string passwordHash, string roleName, UserStatus status)
        {
            Id = id;
            Email = email;
            PasswordHash = passwordHash;
            RoleName = roleName;
            Status = status;
        }

        public Guid Id { get; }
        public string RoleName { get; }
        public string Email { get; }
        public string PasswordHash { get; }
        public UserStatus Status { get; }
    }
}