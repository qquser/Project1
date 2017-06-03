using CommonDomain.Core;
using Project1.Common;
using Project1.Common.Enums;
using Project1.Domain.City.Events;
using Project1.Domain.City.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Domain.City
{
    internal class CityAggregate : AggregateBase
    {
        private CityState _state;

        private CityAggregate(NonEmptyIdentity id)
        {
            Id = id;
        }

        internal CityAggregate(CityState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public CityAggregate(NonEmptyIdentity id, CityName name) : this(id)
        {
            RaiseEvent(new CityAdded(id, name, CityStatus.Active));
        }

        public static CityAggregate Add(Guid id, string name)
        {
            return new CityAggregate(new NonEmptyIdentity(id), new CityName(name));
        }

        public void Rename(CityName newName)
        {
            if (_state.Status == CityStatus.InActive)
            {
                throw new InvalidOperationException("CityAggregate is inactive");
            }
            RaiseEvent(new CityRenamed(Id, newName, _state.Name));
        }

        public void MakeInActive()
        {
            if (_state.Status == CityStatus.InActive)
            {
                throw new InvalidOperationException("CityAggregate is inactive");
            }

            RaiseEvent(new CityMarkedAsInActive(Id));
        }

        private void Apply(CityAdded @event)
        {
            _state = new CityState
            {
                Id = new NonEmptyIdentity(Id),
                Name = new CityName(@event.Name),
                Status = @event.Status
            };
        }

        private void Apply(CityRenamed @event)
        {
            _state.Name = new CityName(@event.NewName);
        }

        private void Apply(CityMarkedAsInActive @event)
        {
            _state.Status = CityStatus.InActive;
        }
    }
}
