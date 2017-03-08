using System;
using CommonDomain.Persistence;
using Project1.Domain.Project.ValueObjects;

namespace Project1.Domain.Project.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository _repository;

        public ProjectService(IRepository repository)
        {
            _repository = repository;
        }

        public void AddProject(Guid projectId, string name)
        {
            var project = ProjectAggregate.Add(projectId, name);
            _repository.Save(project, Guid.NewGuid(), null);
        }

        public void Rename(Guid projectId, string newName)
        {
            var project = _repository.GetById<ProjectAggregate>(projectId);
            project.Rename(new ProjectName(newName));
            _repository.Save(project, Guid.NewGuid(), null);
        }

        public void MakeInActive(Guid projectId)
        {
            var project = _repository.GetById<ProjectAggregate>(projectId);
            project.MakeInActive();
            _repository.Save(project, Guid.NewGuid(), null);
        }
    }
}