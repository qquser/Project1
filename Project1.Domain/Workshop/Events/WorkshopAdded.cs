using Project1.Common.Enums;
using Project1.Common.Events.Workshop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Domain.Workshop.Events
{
    internal class WorkshopAdded : IWorkshopAdded
    {
        public WorkshopAdded(Guid id, string name, Guid cityId, WorkshopStatus status)
        {
            Id = id;
            Name = name;
            CityId = cityId;
            Status = status;
        }

        public Guid Id { get; }
        public string Name { get; }
        public Guid CityId { get; }
        public WorkshopStatus Status { get; }
    }
}
