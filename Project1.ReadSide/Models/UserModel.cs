using System;
using System.Collections.Generic;
using Project1.Common.Enums;
using Project1.ReadSide.Helpers;

namespace Project1.ReadSide.Models
{
    public class UserModel : BaseModel
    {
        private UserModel()
        {
        }
        public UserModel(Guid id) : base(id)
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserStatus Status { get; set; }

        public string RoleId { get; set; }
        public RoleModel RoleModel { get; set; }

        public ICollection<JobModel> Jobs { get; set; }
    }
}