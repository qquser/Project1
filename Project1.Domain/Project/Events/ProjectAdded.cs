using System;
using Project1.Common.Enums;
using Project1.Common.Events.Project;

namespace Project1.Domain.Project.Events
{
    internal class ProjectAdded : IProjectAdded
    {
        public ProjectAdded(Guid id, string name, ProjectStatus status)
        {
            Id = id;
            Name = name;
            Status = status;
        }

        public Guid Id { get; }
        public string Name { get; }
        public ProjectStatus Status { get; }
    }
}