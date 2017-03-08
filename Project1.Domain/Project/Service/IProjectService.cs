using System;

namespace Project1.Domain.Project.Service
{
    public interface IProjectService : IDomainService
    {
        void AddProject(Guid projectId, string name);
        void MakeInActive(Guid projectId);
        void Rename(Guid projectId, string newName);
    }
}