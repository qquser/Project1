using MassTransit;
using Project1.Common.Commands.Job;
using Project1.Domain.Job.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.WriteSide.Handlers.Job
{
    public class JobHandler :
        IConsumer<IAddJob>,
        IConsumer<IMakeJobInActive>,
        IConsumer<IRenameJob>
    {
        private readonly IJobService _service;

        public JobHandler(IJobService service)
        {
            _service = service;
        }

        public async Task Consume(ConsumeContext<IAddJob> context)
        {

            await Task.Run(() => _service.AddJob(
                context.Message.Id,
                context.Message.Name,
                context.Message.UserId,
                context.Message.WorkshopId));
        }

        public async Task Consume(ConsumeContext<IMakeJobInActive> context)
        {
            await Task.Run(() => _service.MakeInActive(context.Message.Id));
        }

        public async Task Consume(ConsumeContext<IRenameJob> context)
        {
            await Task.Run(() => _service.Rename(context.Message.Id, context.Message.NewName));
        }
    }
}
