using Project1.Application.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Commands
{
    internal class AuthorizationCommandDecorator<TModel> : BaseCommand<TModel> where TModel : IModel
    {
        public AuthorizationCommandDecorator(BaseCommand<TModel> decoratedCommand, TModel model) 
        {
        }

        public override void Validate(TModel model)
        {
        }
    }
}
