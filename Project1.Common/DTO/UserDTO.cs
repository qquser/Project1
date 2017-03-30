using Project1.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Common.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserStatus Status { get; set; }

        //public string FirstName { get; set; }
        //public string LastName { get; set; }

        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
