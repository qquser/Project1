using System;

namespace Project1.Domain.Customer.Service
{
    public interface ICustomerService : IDomainService
    {
        void Add(Guid id, string name);
        void Rename(Guid id, string newName);
        void MakeInActive(Guid id);
    }
}