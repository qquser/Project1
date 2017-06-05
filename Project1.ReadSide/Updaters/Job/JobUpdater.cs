using MassTransit;
using Project1.Common.Enums;
using Project1.Common.Events.Job;
using Project1.ReadSide.Helpers;
using Project1.ReadSide.Interfaces;
using Project1.ReadSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.ReadSide.Updaters.Job
{
    public class JobUpdater :
        IConsumer<IJobAdded>,
        IConsumer<IJobRenamed>,
        IConsumer<IJobMarkedAsInActive>
    {
        private readonly IModelUpdater _context;

        public JobUpdater(IModelUpdater context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<IJobAdded> context)
        {
            var job = new JobModel(context.Message.Id)
            {
                Description = context.Message.Name,
                Status = context.Message.Status,
                UserId = BaseModel.MakeId(typeof(UserModel), context.Message.UserId),
                WorkshopId = BaseModel.MakeId(typeof(WorkshopModel), context.Message.WorkshopId),
            };
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
        }

        public async Task Consume(ConsumeContext<IJobRenamed> context)
        {
            var job = _context.Jobs.FindAggregate(context.Message.Id);
            job.Description = context.Message.NewName;
            await _context.SaveChangesAsync();
        }

        public async Task Consume(ConsumeContext<IJobMarkedAsInActive> context)
        {
            var job = _context.Jobs.FindAggregate(context.Message.Id);
            job.Status = JobStatus.InActive;
            await _context.SaveChangesAsync();
        }
    }
}
