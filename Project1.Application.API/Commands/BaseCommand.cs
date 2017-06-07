using Project1.Application.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Commands
{
    internal abstract class BaseCommand<TModel> where TModel : IModel
    {
        public abstract void Validate(TModel model);

    }
}
