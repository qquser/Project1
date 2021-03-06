﻿using Project1.Application.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Commands
{
    public interface IBaseCommand<TModel> where TModel : IModel
    {
        IBaseCommand<TModel> DecoratedHandler { get; }
        void Handle(TModel model);
    }
}
