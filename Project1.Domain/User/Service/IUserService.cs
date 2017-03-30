using Project1.Domain.User.ValueObjects;
using System;

namespace Project1.Domain.User.Service
{
    public interface IUserService : IDomainService
    {
        UserState Add(Guid id, string firstName, string lastName);
        void Promote(Guid userId);
        void Demote(Guid userId);
    }
}