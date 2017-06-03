using Project1.Application.API.Models.Workshop;
using Project1.Common.Commands.Workshop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Commands.Workshop
{
    public class RenameWorkshopCommand : IRenameWorkshop
    {
        private readonly RenameWorkshopModel _model;

        public RenameWorkshopCommand(RenameWorkshopModel model, Guid id)
        {
            _model = model;
            Timestamp = DateTime.UtcNow;
            Id = id;
        }

        public Guid Id { get; }
        public string NewName => _model.NewName;
        public DateTime Timestamp { get; }
        public Guid CommandId => _model.CommandId;
    }
}
