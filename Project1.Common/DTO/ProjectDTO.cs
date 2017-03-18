using System;
using System.Collections.Generic;
using System.Text;
using Project1.Common.Enums;

namespace Project1.Common.DTO
{
    public class ProjectDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProjectStatus Status { get; set; }
        public List<Guid> AssignedUsersIds { get; set; }

        public string CustomerId { get; set; }
    }
}
