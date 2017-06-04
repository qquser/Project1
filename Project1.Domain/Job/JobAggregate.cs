using CommonDomain.Core;
using Project1.Common;
using Project1.Common.Enums;
using Project1.Domain.Job.Events;
using Project1.Domain.Job.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Domain.Job
{
    internal class JobAggregate : AggregateBase
    {
        private JobState _state;

        private JobAggregate(NonEmptyIdentity id)
        {
            Id = id;
        }

        internal JobAggregate(JobState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public JobAggregate(NonEmptyIdentity id, JobName name, Guid userId, Guid workshopId) : this(id)
        {
            RaiseEvent(new JobAdded(id, name, JobStatus.Active, userId, workshopId));
        }

        public static JobAggregate Add(Guid id, string name, Guid userId, Guid workshopId)
        {
            return new JobAggregate(new NonEmptyIdentity(id), new JobName(name), userId, workshopId);
        }

        public void Rename(JobName newName)
        {
            if (_state.Status == JobStatus.InActive)
            {
                throw new InvalidOperationException("Job is inactive");
            }
            RaiseEvent(new JobRenamed(Id, newName, _state.Name));
        }

        public void MakeInActive()
        {
            if (_state.Status == JobStatus.InActive)
            {
                throw new InvalidOperationException("Job is inactive");
            }
            RaiseEvent(new JobMarkedAsInActive(Id));
        }

        private void Apply(JobAdded @event)
        {
            _state = new JobState
            {
                Id = new NonEmptyIdentity(Id),
                Name = new JobName(@event.Name),
                Status = @event.Status,
                UserId = new NonEmptyIdentity(@event.UserId),
                WorkshopId = new NonEmptyIdentity(@event.WorkshopId),
            };
        }

        private void Apply(JobRenamed @event)
        {
            _state.Name = new JobName(@event.NewName);
        }

        private void Apply(JobMarkedAsInActive @event)
        {
            _state.Status = JobStatus.InActive;
        }
    }
}
