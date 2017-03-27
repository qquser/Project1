using System;
using Project1.Common.Enums;

namespace Project1.Common.Events.UserAdded
{
    public interface IUserRegistred
    {
        Guid Id { get; }
        string Email { get; }
        string PasswordHash { get; }
        string RoleName { get; }
    }
}