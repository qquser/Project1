using System;

namespace Project1.Domain.User.Service
{
    public interface IUserService : IDomainService
    {
        void Add(Guid id, string firstName, string lastName);
        void Promote(Guid userId);
        void Demote(Guid userId);
    }
}