using AutoMapper;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Project1.Common.DTO;
using Project1.Common.Queries.Workshop;
using Project1.ReadSide.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.ReadSide.Readers
{
    class WorkshopReader :
        IConsumer<IGetAllWorkshops>,
        IConsumer<IGetWorkshop>
    {
        private readonly IModelReader _reader;
        private readonly IMapper _mapper;

        public WorkshopReader(IModelReader reader, IMapper mapper)
        {
            _reader = reader;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<IGetAllWorkshops> context)
        {
            var workshops = _reader.Workshops
               .Include(x => x.CityModel)
               .Select(_mapper.Map<WorkshopDTO>)
               .ToList();
            var respond = new GetAllWorkshopsResult(workshops);
            await context.RespondAsync(respond);
        }

        public async Task Consume(ConsumeContext<IGetWorkshop> context)
        {
            var workshop = _mapper.Map<WorkshopDTO>(_reader.Workshops
                 .Include(x => x.CityModel)
                 .FirstOrDefault(x => x.AggregateId == context.Message.Id));
            var respond = new GetWorkshopResult(workshop);
            await context.RespondAsync(respond);
        }

        class GetAllWorkshopsResult : IGetAllWorkshopsResult
        {
            public GetAllWorkshopsResult(List<WorkshopDTO> workshops)
            {
                Workshops = workshops;
            }

            public List<WorkshopDTO> Workshops { get; }
        }

        class GetWorkshopResult : IGetWorkshopResult
        {
            public GetWorkshopResult(WorkshopDTO workshop)
            {
                Workshop = workshop;
            }

            public WorkshopDTO Workshop { get; }
        }
    }
}
