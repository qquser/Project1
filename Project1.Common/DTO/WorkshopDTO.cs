using Project1.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Common.DTO
{
    public class WorkshopDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public WorkshopStatus Status { get; set; }
        public string CityId { get; set; }
        public List<Guid> JobIds { get; set; }
    }
}
