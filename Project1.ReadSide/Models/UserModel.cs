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
        public ICollection<ProjectModel> AssignedProjects { get; set; }
        public UserRole Role { get; set; }
    }
}