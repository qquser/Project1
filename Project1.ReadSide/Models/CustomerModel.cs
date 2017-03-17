using System;
using System.Collections.Generic;
using Project1.Common.Enums;
using Project1.ReadSide.Helpers;

namespace Project1.ReadSide.Models
{
    public class CustomerModel : BaseModel
    {
        private CustomerModel()
        {
        }

        public CustomerModel(Guid id) : base(id)
        {
        }

        public string Name { get; set; }
        public CustomerStatus Status { get; set; }
        public ICollection<ProjectModel> Projects { get; set; }
    }
}