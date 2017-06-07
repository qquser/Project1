﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Project1.Application.API.Bus;
using Project1.Application.API.Commands;
using Project1.Application.API.Composition_root;
using Project1.Application.API.Models;

namespace Project1.Application.API.Controllers
{
    public abstract class EnhancedApiController : Controller
    {
        //protected IHttpActionResult Accepted<T>(T value)
        //{
        //    return new AcceptedActionResult<T>(Request, value);
        //}

        //TODO глаза слезяться маленечко, но зато декораторы запускаются, как надо прям
        protected TCommand GetCommand<TCommand, TModel>(TCommand command, TModel model) 
            where TModel : IModel 
            where TCommand : IBaseCommand<TModel>
        {
            Bootstrapper.GetInstance<IBaseCommand<TModel>>().Handle(model);
            return command;
        }

        protected async Task Send<TMessage>(TMessage message,
            CancellationToken cancellationToken = default(CancellationToken))
            where TMessage : class
        {
            await BusControl.Send(message, cancellationToken);
        }

        protected async Task<TResponse> SendRequest<TRequest, TResponse>(TRequest request,
            CancellationToken cancellationToken = default(CancellationToken))
            where TRequest : class
            where TResponse : class
        {
            return await BusControl.SendRequest<TRequest, TResponse>(request, cancellationToken);
        }
    }
}
