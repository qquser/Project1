using Project1.Common.Events.Workshop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Domain.Workshop.Events
{
    internal class WorkshopMarkedAsInActive : IWorkshopMarkedAsInActive
    {
        public WorkshopMarkedAsInActive(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
