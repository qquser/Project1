using CommonDomain.Core;
using Project1.Common;
using Project1.Domain.Workshop.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Common;
using Project1.Domain.Workshop.ValueObjects;
using Project1.Common.Enums;
using Project1.Domain.Workshop.Events;

namespace Workshop1.Domain.Workshop
{
    internal class WorkshopAggregate : AggregateBase
    {
        private WorkshopState _state;

        private WorkshopAggregate(NonEmptyIdentity id)
        {
            Id = id;
        }

        internal WorkshopAggregate(WorkshopState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
            _state = state;
        }

        public WorkshopAggregate(NonEmptyIdentity id, WorkshopName name, NonEmptyIdentity customerId) : this(id)
        {
            RaiseEvent(new WorkshopAdded(id, name, customerId, WorkshopStatus.Active));
        }

        public static WorkshopAggregate Add(Guid id, string name, Guid cityId)
        {
            return new WorkshopAggregate(new NonEmptyIdentity(id), new WorkshopName(name),
                new NonEmptyIdentity(cityId));
        }

        public void Rename(WorkshopName newName)
        {
            if (_state.Status == WorkshopStatus.InActive)
            {
                throw new InvalidOperationException("Workshop is inactive");
            }
            RaiseEvent(new WorkshopRenamed(Id, newName, _state.Name));
        }

        public void MakeInActive()
        {
            if (_state.Status == WorkshopStatus.InActive)
            {
                throw new InvalidOperationException("Workshop is inactive");
            }
            RaiseEvent(new WorkshopMarkedAsInActive(Id));
        }

        private void Apply(WorkshopAdded @event)
        {
            _state = new WorkshopState
            {
                Id = new NonEmptyIdentity(Id),
                Name = new WorkshopName(@event.Name),
                Status = @event.Status,
                CityId = new NonEmptyIdentity(@event.CityId)
            };
        }

        private void Apply(WorkshopRenamed @event)
        {
            _state.Name = new WorkshopName(@event.NewName);
        }

        private void Apply(WorkshopMarkedAsInActive @event)
        {
            _state.Status = WorkshopStatus.InActive;
        }
    }
}
