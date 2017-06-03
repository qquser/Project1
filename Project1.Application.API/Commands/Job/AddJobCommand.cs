using Project1.Application.API.Models.Job;
using Project1.Common.Commands.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Commands.Job
{
    public class AddJobCommand : IAddJob
    {
        private readonly AddJobModel _model;

        public AddJobCommand(AddJobModel model)
        {
            _model = model;
            Timestamp = DateTime.UtcNow;
        }

        public DateTime Timestamp { get; }
        public Guid CommandId => _model.CommandId;
        public Guid Id => _model.JobId;
        public string Name => _model.Name;
        public Guid WorkshopId => _model.WorkshopId;
        public Guid UserId => _model.UserId;
    }
}
