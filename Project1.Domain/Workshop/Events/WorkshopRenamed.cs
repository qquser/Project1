using Project1.Common.Events.Workshop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Domain.Workshop.Events
{
    internal class WorkshopRenamed : IWorkshopRenamed
    {
        public WorkshopRenamed(Guid id, string newName, string oldName)
        {
            Id = id;
            NewName = newName;
            OldName = oldName;
        }

        public Guid Id { get; }
        public string NewName { get; }
        public string OldName { get; }
    }
}
