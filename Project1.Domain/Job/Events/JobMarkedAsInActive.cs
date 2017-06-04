using Project1.Common.Events.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Domain.Job.Events
{
    internal class JobMarkedAsInActive : IJobMarkedAsInActive
    {
        public JobMarkedAsInActive(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
