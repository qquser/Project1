using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Commands
{
    //TODO через нинжект плз
    public abstract class Decorator<TModel>
    {
        public Decorator(TModel model)
        {
            Validate(model);
        }
        protected abstract void Validate(TModel model);

    }
}
