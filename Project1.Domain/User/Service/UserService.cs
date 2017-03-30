using System;
using CommonDomain.Persistence;
using Project1.Common;
using Project1.Domain.User.ValueObjects;

namespace Project1.Domain.User.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public UserState Add(Guid id, string email, string hash)
        {
            var user = UserAggregate.Add(id, email, hash);
            _repository.Save(user, Guid.NewGuid(), null);
            return user.State;
        }

        public void Promote(Guid userId)
        {
            var user = _repository.GetById<UserAggregate>(userId);
            user.Promote();
            _repository.Save(user, Guid.NewGuid(), null);
        }

        public void Demote(Guid userId)
        {
            var user = _repository.GetById<UserAggregate>(userId);
            user.Demote();
            _repository.Save(user, Guid.NewGuid(), null);
        }
    }
}