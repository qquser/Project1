using AutoMapper;
using MassTransit;
using Project1.Common.DTO;
using Project1.Common.Queries.City;
using Project1.ReadSide.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.ReadSide.Readers
{
    public class CityReader :
           IConsumer<IGetAllCities>,
           IConsumer<IGetCity>
    {
        private readonly IModelReader _reader;
        private readonly IMapper _mapper;

        public CityReader(IModelReader reader, IMapper mapper)
        {
            _reader = reader;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<IGetAllCities> context)
        {
            var customers = _reader.Cities
                .Select(_mapper.Map<CityDTO>)
                .ToList();
            var respond = new GetAllCitiesResult(customers);
            await context.RespondAsync(respond);
        }

        public async Task Consume(ConsumeContext<IGetCity> context)
        {
            var city = _mapper.Map<CityDTO>(_reader.Cities
                .FirstOrDefault(x => x.AggregateId == context.Message.Id));
            var respond = new GetCityResult(city);
            await context.RespondAsync(respond);
        }

        class GetAllCitiesResult : IGetAllCitiesResult
        {
            public GetAllCitiesResult(List<CityDTO> cities)
            {
                Cities = cities;
            }

            public List<CityDTO> Cities { get; }
        }

        class GetCityResult : IGetCityResult
        {
            public GetCityResult(CityDTO city)
            {
                City = city;
            }

            public CityDTO City { get; }
        }
    }
}
