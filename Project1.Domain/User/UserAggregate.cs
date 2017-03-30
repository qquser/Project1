using System;
using CommonDomain.Core;
using Project1.Common;
using Project1.Common.Enums;
using Project1.Domain.User.Events;
using Project1.Domain.User.ValueObjects;

namespace Project1.Domain.User
{
    internal class UserAggregate : AggregateBase
    {
        internal UserState State { get; private set; }

        private UserAggregate(NonEmptyIdentity id)
        {
            Id = id;
        }

        internal UserAggregate(UserState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
            State = state;
        }

        public UserAggregate(NonEmptyIdentity id, UserName name) : this(id)
        {
            RaiseEvent(new UserRegistred(id, name.Email, name.PasswordHash, UserRole.User.ToString(), UserStatus.Active));
        }

        public static UserAggregate Add(Guid id, string email, string hash)
        {
            return new UserAggregate(new NonEmptyIdentity(id), new UserName(email, hash));
        }


        public void Promote()
        {
            //if (_state.Role == UserRole.Manager)
            //{
            //    throw new ArgumentException("Cannot promote");
            //}
            //RaiseEvent(new UserPromoted(Id));
        }

        public void Demote()
        {
            //if (_state.Role == UserRole.None)
            //{
            //    throw new ArgumentException("Cannot demote");
            //}
            //RaiseEvent(new UserDemoted(Id));
        }

        private void Apply(UserRegistred @event)
        {
            State = new UserState
            {
                Id = new NonEmptyIdentity(@event.Id),
                UserName = new UserName(@event.Email, @event.PasswordHash),
                RoleName = @event.RoleName,
                Status = @event.Status
            };
        }

        private void Apply(UserPromoted @event)
        {
            State.RoleName = UserRole.Manager.ToString();
        }

        private void Apply(UserDemoted @event)
        {
            State.RoleName = UserRole.None.ToString();
        }
    }
}