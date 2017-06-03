using Project1.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Common.Queries.City
{
    public interface IGetCity
    {
        Guid Id { get; }
    }

    public interface IGetCityResult
    {
        CityDTO Customer { get; }
    }
}
