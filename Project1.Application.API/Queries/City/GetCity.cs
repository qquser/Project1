using Project1.Common.Queries.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Queries.City
{
    public class GetCity : IGetCity
    {
        public GetCity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
