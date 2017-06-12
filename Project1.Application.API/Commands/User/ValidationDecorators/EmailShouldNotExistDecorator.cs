using Project1.Application.API.Bus;
using Project1.Application.API.Models;
using Project1.Application.API.Models.User;
using Project1.Application.API.Queries.User;
using Project1.Common.Enums;
using Project1.Common.Queries.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Commands.User.ValidationDecorators
{
    internal class EmailShouldNotExistDecorator<TModel> : IBaseCommand<TModel> where TModel : IEmailShouldNotExistModel 
    {
        private readonly IBaseCommand<TModel> _decoratedHandler;
        public IBaseCommand<TModel> DecoratedHandler => _decoratedHandler;

        public EmailShouldNotExistDecorator(IBaseCommand<TModel> decoratedCommand)
        {
            _decoratedHandler = decoratedCommand;
        }

        public void Handle(TModel model)
        {
            Validate(model);
            _decoratedHandler.Handle(model);
        }

        public void Validate(TModel model)
        {
            var query = new GetUserByEmail(model.Email);
            var result = BusControl.SendRequest<IGetUserByEmail, IGetUserResult>(query).Result;
            if (result.User != null)
                throw new Exception(ExceptionInfo.EmailAlreadyExists.Message);
        }

    }
}
