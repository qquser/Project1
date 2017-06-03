using MassTransit;
using Project1.Common.Commands.City;
using Project1.Domain.City.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.WriteSide.Handlers.City
{
    public class CityHandler :
        IConsumer<IAddCity>,
        IConsumer<IMakeCityInActive>,
        IConsumer<IRenameCity>
    {
        private readonly ICityService _service;

        public CityHandler(ICityService service)
        {
            _service = service;
        }

        public async Task Consume(ConsumeContext<IAddCity> context)
        {
            await Task.Run(() => _service.Add(context.Message.Id, context.Message.Name));
        }

        public async Task Consume(ConsumeContext<IMakeCityInActive> context)
        {
            await Task.Run(() => _service.MakeInActive(context.Message.Id));
        }

        public async Task Consume(ConsumeContext<IRenameCity> context)
        {
            await Task.Run(() => _service.Rename(context.Message.Id, context.Message.NewName));
        }
    }
}
