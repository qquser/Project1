using Project1.Application.API.Commands.User.ValidationDecorators;
using Project1.Application.API.CrossCuttingConcerns;
using Project1.Application.API.Helpers;
using Project1.Application.API.Models;
using Project1.Application.API.Models.User;
using Project1.Common;
using Project1.Common.Commands.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Commands.User
{
    internal class RegisterUserCommand : IBaseCommand<RegisterUserModel>, IRegisterUser
    {
        private readonly RegisterUserModel _model;

        public RegisterUserCommand(RegisterUserModel model)
        {
            _model = model;
            Timestamp = DateTime.UtcNow;
        }

        public Guid Id => _model.Id;
        public string Email => _model.Email;
        public string PasswordHash => Hashing.HashPassword(_model.ConfirmPassword);

        public DateTime Timestamp { get; }
        public Guid CommandId => _model.CommandId;

        public void Handle(RegisterUserModel model)
        {

        }
    }


}
