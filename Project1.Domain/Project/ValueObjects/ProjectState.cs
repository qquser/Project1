using Project1.Common;
using Project1.Common.Enums;

namespace Project1.Domain.Project.ValueObjects
{
    internal class ProjectState
    {
        public NonEmptyIdentity Id { get; set; }
        public ProjectStatus Status { get; set; }
        public ProjectName Name { get; set; }
    }
}