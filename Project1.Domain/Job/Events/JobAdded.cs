using Project1.Common.Enums;
using Project1.Common.Events.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Domain.Job.Events
{
    internal class JobAdded : IJobAdded
    {
        public JobAdded(Guid id, string name, JobStatus status, Guid userId, Guid workshopId)
        {
            Id = id;
            Name = name;
            Status = status;
            UserId = userId;
            WorkshopId = workshopId;
        }

        public Guid Id { get; }
        public string Name { get; }
        public JobStatus Status { get; }

        public Guid WorkshopId { get; }
        public Guid UserId { get; }
    }
}
