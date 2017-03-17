using Project1.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Common.DTO
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CustomerStatus Status { get; set; }
        public List<Guid> ProjectIds { get; set; }
    }
}
