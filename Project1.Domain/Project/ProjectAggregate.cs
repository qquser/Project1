using System;
using CommonDomain.Core;
using Project1.Common;
using Project1.Common.Enums;
using Project1.Domain.Project.Events;
using Project1.Domain.Project.ValueObjects;


namespace Project1.Domain.Project
{
    internal class ProjectAggregate : AggregateBase
    {
        private ProjectState _state;

        private ProjectAggregate(NonEmptyIdentity id)
        {
            Id = id;
        }

        internal ProjectAggregate(ProjectState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
            _state = state;
        }

        public ProjectAggregate(NonEmptyIdentity id, ProjectName name) : this(id)
        {
            RaiseEvent(new ProjectAdded(id, name, ProjectStatus.Active));
        }

        public static ProjectAggregate Add(Guid id, string name)
        {
            return new ProjectAggregate(new NonEmptyIdentity(id), new ProjectName(name));
        }

        public void Rename(ProjectName newName)
        {
            if (_state.Status == ProjectStatus.InActive)
            {
                throw new InvalidOperationException("Project is inactive");
            }
            RaiseEvent(new ProjectRenamed(Id, newName, _state.Name));
        }

        public void MakeInActive()
        {
            if (_state.Status == ProjectStatus.InActive)
            {
                throw new InvalidOperationException("Project is inactive");
            }
            RaiseEvent(new ProjectMarkedAsInActive(Id));
        }

        private void Apply(ProjectAdded @event)
        {
            _state = new ProjectState
            {
                Id = new NonEmptyIdentity(Id),
                Name = new ProjectName(@event.Name),
                Status = @event.Status,
            };
        }

        private void Apply(ProjectRenamed @event)
        {
            _state.Name = new ProjectName(@event.NewName);
        }

        private void Apply(ProjectMarkedAsInActive @event)
        {
            _state.Status = ProjectStatus.InActive;
        }
    }
}