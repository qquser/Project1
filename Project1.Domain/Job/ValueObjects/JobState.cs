using Project1.Common;
using Project1.Common.Enums;
using Project1.Domain.User.ValueObjects;
using Project1.Domain.Workshop.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Domain.Job.ValueObjects
{
    internal class JobState
    {
        public NonEmptyIdentity Id { get; set; }
        public JobStatus Status { get; set; }
        public JobName Name { get; set; }

        public NonEmptyIdentity WorkshopId { get; set; }
        public WorkshopState WorkshopState { get; set; }

        public NonEmptyIdentity UserId { get; set; }
        public UserState UserState { get; set; }
    }
}
