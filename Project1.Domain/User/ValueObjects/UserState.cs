using System.Collections.Generic;
using Project1.Common;
using Project1.Common.Enums;

namespace Project1.Domain.User.ValueObjects
{
    public class UserState
    {
        public NonEmptyIdentity Id { get; set; }
        public UserName UserName { get; set; }
        public UserRole Role { get; set; }
        public List<NonEmptyIdentity> AssignedProjectIds { get; set; } = new List<NonEmptyIdentity>();
    }
}