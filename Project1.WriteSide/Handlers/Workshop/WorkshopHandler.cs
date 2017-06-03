using MassTransit;
using Project1.Common.Commands.Workshop;
using Project1.Domain.Workshop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.WriteSide.Handlers.Workshop
{
    public class WorkshopHandler :
        IConsumer<IAddWorkshop>,
        IConsumer<IMakeWorkshopInActive>,
        IConsumer<IRenameWorkshop>
    {
        private readonly IWorkshopService _service;

        public WorkshopHandler(IWorkshopService service)
        {
            _service = service;
        }

        public async Task Consume(ConsumeContext<IAddWorkshop> context)
        {
            await Task.Run(() => _service.AddWorkshop(
                context.Message.Id,
                context.Message.Name,
                context.Message.CityId));
        }

        public async Task Consume(ConsumeContext<IMakeWorkshopInActive> context)
        {
            await Task.Run(() => _service.MakeInActive(context.Message.Id));
        }

        public async Task Consume(ConsumeContext<IRenameWorkshop> context)
        {
            await Task.Run(() => _service.Rename(context.Message.Id, context.Message.NewName));
        }
    }
}
