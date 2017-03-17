using System;
using CommonDomain.Persistence;
using Project1.Common;

namespace Project1.Domain.User.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public void Add(Guid id, string firstName, string lastName)
        {
            var user = UserAggregate.Add(id, firstName, lastName);
            _repository.Save(user, Guid.NewGuid(), null);
        }

        public void AssignToProject(Guid userId, Guid projectId)
        {
            var user = _repository.GetById<UserAggregate>(userId);
            user.AssignToProject(new NonEmptyIdentity(userId));
            _repository.Save(user, Guid.NewGuid(), null);
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