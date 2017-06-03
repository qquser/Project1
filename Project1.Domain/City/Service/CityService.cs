using CommonDomain.Persistence;
using Project1.Domain.City.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Domain.City.Service
{
    public class CityService : ICityService
    {
        private readonly IRepository _repository;

        public CityService(IRepository repository)
        {
            _repository = repository;
        }
        public void Add(Guid id, string name)
        {
            var customer = CityAggregate.Add(id, name);
            _repository.Save(customer, Guid.NewGuid(), null);
        }

        public void Rename(Guid id, string newName)
        {
            var customer = _repository.GetById<CityAggregate>(id);
            customer.Rename(new CityName(newName));
            _repository.Save(customer, Guid.NewGuid(), null);
        }

        public void MakeInActive(Guid id)
        {
            var customer = _repository.GetById<CityAggregate>(id);
            customer.MakeInActive();
            _repository.Save(customer, Guid.NewGuid(), null);
        }
    }
}
