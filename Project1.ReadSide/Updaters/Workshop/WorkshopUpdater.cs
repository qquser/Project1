using MassTransit;
using Project1.Common.Enums;
using Project1.Common.Events.Workshop;
using Project1.ReadSide.Helpers;
using Project1.ReadSide.Interfaces;
using Project1.ReadSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.ReadSide.Updaters.Workshop
{
    internal class WorkshopUpdater :
            IConsumer<IWorkshopAdded>,
            IConsumer<IWorkshopRenamed>,
            IConsumer<IWorkshopMarkedAsInActive>
    {
        private readonly IModelUpdater _context;

        public WorkshopUpdater(IModelUpdater context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<IWorkshopAdded> context)
        {
            var workshop = new WorkshopModel(context.Message.Id)
            {
                Name = context.Message.Name,
                Status = context.Message.Status,
                CityId = BaseModel.MakeId(typeof(CityModel), context.Message.CityId),        
            };
            _context.Workshops.Add(workshop);
            await _context.SaveChangesAsync();
            _context.Dispose();
        }

        public async Task Consume(ConsumeContext<IWorkshopRenamed> context)
        {
            var workshop = _context.Workshops.FindAggregate(context.Message.Id);
            workshop.Name = context.Message.NewName;
            await _context.SaveChangesAsync();
        }

        public async Task Consume(ConsumeContext<IWorkshopMarkedAsInActive> context)
        {
            var workshop = _context.Workshops.FindAggregate(context.Message.Id);
            workshop.Status = WorkshopStatus.InActive;
            await _context.SaveChangesAsync();
        }
    }
}
