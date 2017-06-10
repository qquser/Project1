using System;
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
using Project1.Application.API.CrossCuttingConcerns;

namespace Project1.Application.API.Controllers
{
    public abstract class EnhancedApiController : Controller
    {
        //protected IHttpActionResult Accepted<T>(T value)
        //{
        //    return new AcceptedActionResult<T>(Request, value);
        //}

        protected TCommand GetCommand<TCommand, TModel>(TModel model) 
            where TModel : IModel 
            where TCommand : class, IBaseCommand<TModel>
        {
            Bootstrapper.GetInstance<IBaseCommand<TModel>>().Handle(model); //Вызов Handle для всех декораторов
            var result = Bootstrapper.GetInstance<TCommand>(); 
            result.Handle(model); 
            return result;
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
