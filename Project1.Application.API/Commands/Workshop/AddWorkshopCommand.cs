using Project1.Application.API.Models.Workshop;
using Project1.Common.Commands.Workshop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Commands.Workshop
{
    public class AddWorkshopCommand : IAddWorkshop
    {
        private readonly AddWorkshopModel _model;

        public AddWorkshopCommand(AddWorkshopModel model)
        {
            _model = model;
            Timestamp = DateTime.UtcNow;
        }

        public Guid Id => _model.Id;
        public string Name => _model.Name;
        public DateTime Timestamp { get; }
        public Guid CommandId => _model.CommandId;
        public Guid CityId => _model.CityId;
    }
}
