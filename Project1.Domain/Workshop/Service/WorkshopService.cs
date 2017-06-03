using CommonDomain.Persistence;
using Project1.Domain.Workshop.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop1.Domain.Workshop;

namespace Project1.Domain.Workshop.Service
{
    public class WorkshopService : IWorkshopService
    {
        private readonly IRepository _repository;

        public WorkshopService(IRepository repository)
        {
            _repository = repository;
        }

        public void AddWorkshop(Guid workshopId, string name, Guid cityId)
        {
            var workshop = WorkshopAggregate.Add(workshopId, name, cityId);
            _repository.Save(workshop, Guid.NewGuid(), null);
        }

        public void Rename(Guid workshopId, string newName)
        {
            var workshop = _repository.GetById<WorkshopAggregate>(workshopId);
            workshop.Rename(new WorkshopName(newName));
            _repository.Save(workshop, Guid.NewGuid(), null);
        }

        public void MakeInActive(Guid workshopId)
        {
            var workshop = _repository.GetById<WorkshopAggregate>(workshopId);
            workshop.MakeInActive();
            _repository.Save(workshop, Guid.NewGuid(), null);
        }
    }
}
