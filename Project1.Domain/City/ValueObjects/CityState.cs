using Project1.Common;
using Project1.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Domain.City.ValueObjects
{
    internal class CityState
    {
        public NonEmptyIdentity Id { get; set; }
        public CityStatus Status { get; set; }
        public CityName Name { get; set; }
    }
}
