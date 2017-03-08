using System;
using Project1.Common.Events.Project;

namespace Project1.Domain.Project.Events
{
    internal class ProjectMarkedAsInActive : IProjectMarkedAsInActive
    {
        public ProjectMarkedAsInActive(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}