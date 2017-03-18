using System;
using System.Collections.Generic;
using Project1.Common.Enums;
using Project1.ReadSide.Helpers;

namespace Project1.ReadSide.Models
{
    public class ProjectModel : BaseModel
    {
        private ProjectModel()
        {
        }
        public ProjectModel(Guid id) : base(id)
        {
        }
        public string Name { get; set; }
        public ProjectStatus Status { get; set; }

        public string CustomerId { get; set; }
        public CustomerModel CustomerModel { get; set; }
        public ICollection<UserModel> AssignedUsers { get; set; }
    }
}