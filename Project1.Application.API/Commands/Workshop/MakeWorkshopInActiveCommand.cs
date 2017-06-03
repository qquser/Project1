using Project1.Common.Commands.Workshop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Commands.Workshop
{
    public class MakeWorkshopInActiveCommand : IMakeWorkshopInActive
    {
        public MakeWorkshopInActiveCommand(Guid id, Guid commandId)
        {
            Id = id;
            Timestamp = DateTime.UtcNow;
            CommandId = commandId;
        }

        public Guid Id { get; }
        public DateTime Timestamp { get; }
        public Guid CommandId { get; }
    }
}
