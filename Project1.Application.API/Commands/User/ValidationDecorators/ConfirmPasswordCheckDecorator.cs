using Project1.Application.API.Models;
using Project1.Application.API.Models.User;
using Project1.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Commands.User.ValidationDecorators
{
    internal class ConfirmPasswordCheckDecorator<TModel> : IBaseCommand<TModel> where TModel : IConfirmPasswordCheckModel
    {
        private readonly IBaseCommand<TModel> _decoratedHandler;
        public IBaseCommand<TModel> DecoratedHandler => _decoratedHandler;

        public ConfirmPasswordCheckDecorator(IBaseCommand<TModel> decoratedCommand)
        {
            _decoratedHandler = decoratedCommand;
        }

        private void Validate(TModel model)
        {
            if (model.NewPassword != model.ConfirmPassword)
                throw new Exception(ExceptionInfo.WrongPasswordConfirmation.Message);
        }

        public void Handle(TModel model)
        {
            Validate(model);
            _decoratedHandler.Handle(model);
        }
    }
}
