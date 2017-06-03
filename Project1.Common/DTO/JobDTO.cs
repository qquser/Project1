using Project1.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Common.DTO
{
    public class JobDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public JobStatus Status { get; set; }

        public string WorkshopId { get; set; }
        public string UserId { get; set; }
    }
}
