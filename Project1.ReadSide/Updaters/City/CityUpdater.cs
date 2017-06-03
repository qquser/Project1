using MassTransit;
using Project1.Common.Enums;
using Project1.Common.Events.City;
using Project1.ReadSide.Helpers;
using Project1.ReadSide.Interfaces;
using Project1.ReadSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.ReadSide.Updaters.City
{
    public class CityUpdater :
            IConsumer<ICityAdded>,
            IConsumer<ICityRenamed>,
            IConsumer<ICityMarkedAsInActive>
    {
        private readonly IModelUpdater _context;

        public CityUpdater(IModelUpdater context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<ICityAdded> context)
        {
            var city = new CityModel(context.Message.Id)
            {
                Name = context.Message.Name,
                Status = context.Message.Status
            };
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
            _context.Dispose();
        }

        public async Task Consume(ConsumeContext<ICityRenamed> context)
        {
            var city = _context.Cities.FindAggregate(context.Message.Id);
            city.Name = context.Message.NewName;
            await _context.SaveChangesAsync();
        }

        public async Task Consume(ConsumeContext<ICityMarkedAsInActive> context)
        {
            var city = _context.Cities.FindAggregate(context.Message.Id);
            city.Status = CityStatus.InActive;
            await _context.SaveChangesAsync();
        }
    }
}
