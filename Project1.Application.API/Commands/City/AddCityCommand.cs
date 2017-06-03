using Project1.Application.API.Models.City;
using Project1.Common.Commands.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Commands.City
{
    public class AddCityCommand : IAddCity
    {
        private readonly AddCityModel _model;

        public AddCityCommand(AddCityModel model)
        {
            _model = model;
            Timestamp = DateTime.UtcNow;
        }

        public Guid Id => _model.Id;
        public string Name => _model.Name;
        public DateTime Timestamp { get; }
        public Guid CommandId => _model.CommandId;
    }
}
