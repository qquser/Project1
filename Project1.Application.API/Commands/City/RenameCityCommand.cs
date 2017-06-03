using Project1.Application.API.Models.City;
using Project1.Common.Commands.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Commands.City
{
    public class RenameCityCommand : IRenameCity
    {
        private readonly RenameCityModel _model;

        public RenameCityCommand(RenameCityModel model, Guid id)
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
