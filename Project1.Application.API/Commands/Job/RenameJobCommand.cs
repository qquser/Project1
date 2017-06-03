using Project1.Application.API.Models.Job;
using Project1.Common.Commands.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Commands.Job
{
    public class RenameJobCommand : IRenameJob
    {
        private readonly RenameJobModel _model;

        public RenameJobCommand(RenameJobModel model, Guid id)
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
