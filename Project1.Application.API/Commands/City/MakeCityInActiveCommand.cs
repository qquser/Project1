using Project1.Common.Commands.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Commands.City
{
    public class MakeCityInActiveCommand : IMakeCityInActive
    {
        public MakeCityInActiveCommand(Guid id, Guid commandId)
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
