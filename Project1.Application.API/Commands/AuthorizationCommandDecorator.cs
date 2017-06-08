using Project1.Application.API.Exceptions;
using Project1.Application.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Commands
{
    internal class AuthorizationCommandDecorator<TModel> : IBaseCommand<TModel> where TModel : IModel
    {
        private readonly IBaseCommand<TModel> _decoratedHandler;
        public AuthorizationCommandDecorator(IBaseCommand<TModel> decoratedCommand) 
        {
            _decoratedHandler = decoratedCommand;
            //Validate(decoratedCommand);
        }

        public void Handle(TModel model)
        {
            Validate(model);
            _decoratedHandler.Handle(model);
        }

        private void Validate(TModel command)
        {
            try
            {
                if (command is IAllowedForEveryoneModel)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                throw new AuthorizationException();
            }

        }
    }
}
